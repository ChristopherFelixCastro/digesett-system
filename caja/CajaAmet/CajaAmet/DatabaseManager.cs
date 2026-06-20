using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using Microsoft.Data.Sqlite;

namespace CajaAmet
{
    public static class DatabaseManager
    {
        public static string DerivarClave(string password)
        {
            // Obtener ID único del dispositivo (dirección MAC de la red principal)
            var mac = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Select(n => n.GetPhysicalAddress().ToString())
                .FirstOrDefault();

            if (string.IsNullOrEmpty(mac))
            {
                mac = "DIGESETT_FALLBACK_SALT";
            }

            // Derivar clave con PBKDF2 — 100,000 iteraciones (estándar NIST)
            // En .NET Framework 4.8 instanciamos Rfc2898DeriveBytes indicando SHA256
            using (var pbkdf2 = new Rfc2898DeriveBytes(
                Encoding.UTF8.GetBytes(password),
                Encoding.UTF8.GetBytes(mac),
                100000,
                HashAlgorithmName.SHA256))
            {
                byte[] claveBytes = pbkdf2.GetBytes(32); // 256 bits para AES-256
                return BitConverter.ToString(claveBytes).Replace("-", ""); // Hex string
            }
        }

        public static string ObtenerDbPath()
        {
            var folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Digesett"
            );

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            return Path.Combine(folder, "actas_local.db");
        }

        public static string ObtenerConnectionString(string claveHex)
        {
            var dbPath = ObtenerDbPath();
            return $"Data Source={dbPath};Password={claveHex};";
        }

        public static void InicializarBD(string connectionString)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Tabla principal: Borradores_Actas
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Borradores_Actas (
                            id                     TEXT PRIMARY KEY,
                            conductor_cedula       TEXT NULL,
                            conductor_nombre       TEXT NULL,
                            tipo_infraccion_codigo TEXT NOT NULL,
                            tipo_infraccion_desc   TEXT NOT NULL,
                            monto_base             REAL NOT NULL,
                            placa                  TEXT NULL,
                            url_evidencia          TEXT NULL,
                            descripcion_vehiculo   TEXT NULL,
                            requiere_retencion     INTEGER NOT NULL DEFAULT 0,
                            grua_numero            TEXT NULL,
                            fecha_hecho            TEXT NOT NULL,
                            agente_id              TEXT NOT NULL,
                            estado_sync            TEXT NOT NULL DEFAULT 'PENDIENTE',
                            timestamp_firma        TEXT NULL,
                            error_detalle          TEXT NULL
                        );";
                    cmd.ExecuteNonQuery();
                }

                // Catálogo de infracciones: Infracciones_Cache
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Infracciones_Cache (
                            id                 INTEGER PRIMARY KEY,
                            codigo             TEXT NOT NULL UNIQUE,
                            descripcion        TEXT NOT NULL,
                            categoria          TEXT NOT NULL,
                            monto_particular   REAL NOT NULL,
                            monto_motocicleta  REAL NOT NULL,
                            monto_carga        REAL NOT NULL,
                            requiere_retencion INTEGER NOT NULL DEFAULT 0
                        );";
                    cmd.ExecuteNonQuery();
                }

                // Movimientos de caja: Movimientos_Caja
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Movimientos_Caja (
                            id          INTEGER PRIMARY KEY AUTOINCREMENT,
                            tipo        TEXT NOT NULL,
                            monto       REAL NOT NULL,
                            descripcion TEXT NULL,
                            acta_uuid   TEXT NULL,
                            cajero_id   TEXT NOT NULL,
                            timestamp   TEXT NOT NULL
                        );";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool EjecutarPoC(string password, out string log)
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== INICIANDO PRUEBA DE CONCEPTO (PoC) SQLCIPHER ===");

            try
            {
                // 1. Derivar clave
                sb.AppendLine("1. Derivando clave con PBKDF2 (100,000 iteraciones + SHA-256 + MAC Salt)...");
                string claveHex = DerivarClave(password);
                sb.AppendLine($"   Clave derivada (Hex truncated): {claveHex.Substring(0, 8)}...");

                // 2. Obtener connection string e inicializar BD
                string connString = ObtenerConnectionString(claveHex);
                string dbPath = ObtenerDbPath();
                sb.AppendLine($"2. Ruta de la BD: {dbPath}");
                sb.AppendLine("3. Abriendo base de datos e inicializando tablas...");
                InicializarBD(connString);
                sb.AppendLine("   Tablas creadas/verificadas con éxito.");

                // 4. Intentar escritura (INSERT de prueba)
                sb.AppendLine("4. Insertando registro de prueba en 'Movimientos_Caja'...");
                string testId = Guid.NewGuid().ToString();
                string timestamp = DateTime.Now.ToString("o");
                using (var connection = new SqliteConnection(connString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            INSERT INTO Movimientos_Caja (tipo, monto, descripcion, cajero_id, timestamp)
                            VALUES ('ENTRADA', 100.0, 'POC_TEST_INSERT', 'AGENTE_POC', @timestamp);";
                        cmd.Parameters.AddWithValue("@timestamp", timestamp);
                        cmd.ExecuteNonQuery();
                    }
                }
                sb.AppendLine("   Escritura exitosa.");

                // 5. Intentar lectura (SELECT de prueba)
                sb.AppendLine("5. Leyendo registro de prueba desde la base de datos...");
                bool recordFound = false;
                using (var connection = new SqliteConnection(connString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT tipo, monto, descripcion FROM Movimientos_Caja WHERE descripcion = 'POC_TEST_INSERT';";
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string tipo = reader.GetString(0);
                                double monto = reader.GetDouble(1);
                                string desc = reader.GetString(2);
                                sb.AppendLine($"   Registro leído: Tipo={tipo}, Monto={monto}, Desc={desc}");
                                recordFound = true;
                            }
                        }
                    }

                    // Limpiar prueba
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Movimientos_Caja WHERE descripcion = 'POC_TEST_INSERT';";
                        cmd.ExecuteNonQuery();
                    }
                }

                if (!recordFound)
                {
                    throw new Exception("El registro de prueba no pudo ser leído de la base de datos.");
                }
                sb.AppendLine("   Lectura y limpieza completadas con éxito.");

                // 6. Validar que la base de datos realmente está cifrada
                sb.AppendLine("6. Validando seguridad: Intentando abrir con clave incorrecta...");
                string incorrectConnString = ObtenerConnectionString("CLAVE_INCORRECTA_POC_12345");
                try
                {
                    using (var connection = new SqliteConnection(incorrectConnString))
                    {
                        connection.Open();
                        // Ejecutar un comando para forzar la lectura del archivo cifrado
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "SELECT count(*) FROM Borradores_Actas;";
                            cmd.ExecuteScalar();
                        }
                    }
                    sb.AppendLine("   [ALERTA/FALLO]: ¡La base de datos se abrió con una clave incorrecta!");
                    log = sb.ToString();
                    return false;
                }
                catch (SqliteException ex)
                {
                    sb.AppendLine($"   [ÉXITO DE SEGURIDAD]: Se denegó el acceso con clave incorrecta.");
                    sb.AppendLine($"   Detalle del error (esperado): {ex.Message} (Código: {ex.SqliteErrorCode})");
                }

                sb.AppendLine("\n>>> PoC COMPLETADA CON ÉXITO: SQLCipher cifra y protege la base de datos local.");
                log = sb.ToString();
                return true;
            }
            catch (Exception ex)
            {
                sb.AppendLine($"\n[ERROR PoC]: {ex.Message}");
                sb.AppendLine(ex.StackTrace);
                log = sb.ToString();
                return false;
            }
        }
    }
}
