# Manual de Instalación - DIGESETT Middleware

## Requisitos Previos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server Express 2022](https://www.microsoft.com/sql-server/sql-server-downloads) (seleccionar Express)
- [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup)
- [Visual Studio 2022 Community](https://visualstudio.microsoft.com/downloads/)
- [Git](https://git-scm.com/downloads)

## Clonar Repositorio
```bash
git clone https://github.com/[org]/digesett-system.git
cd digesett-system
```

## Configurar SQL Server
1. Abrir SQL Server Configuration Manager.
2. Ir a SQL Server Network Configuration → Protocols for SQLEXPRESS → TCP/IP → Enable.
3. Reiniciar el servicio SQL Server (SQLEXPRESS).
4. Abrir SSMS y conectarse a `localhost\SQLEXPRESS` con Windows Authentication.
5. Crear nueva base de datos llamada `DigesettMiddleware`.
6. Abrir y ejecutar el script `sql-scripts/schema_middleware.sql`.
7. Abrir y ejecutar el script `sql-scripts/seed_middleware.sql`.
8. Verificar que la base de datos tiene datos ejecutando: `SELECT COUNT(*) FROM MockConductores`. Debe dar 10.

## Configurar Proyecto
1. Navegar a la carpeta `middleware/Digesett.Middleware/`.
2. Copiar el archivo `appsettings.Development.json.example` como `appsettings.Development.json`.
3. Editar `appsettings.Development.json`:
   - En `ConnectionStrings`, cambiar `localhost\SQLEXPRESS` por el nombre de tu instancia si es diferente.
   - En `Jwt.SecretKey`, poner la clave que Antony comparte por canal privado.

## Ejecutar
```bash
cd middleware/Digesett.Middleware
dotnet restore
dotnet run
```
Abrir en el navegador: [http://localhost:6001/swagger](http://localhost:6001/swagger)

## Verificación (Endpoints de Prueba)
1. `GET /api/mock/jce/cedula/001-0000001-0` → debe responder estado ACTIVO
2. `GET /api/mock/dgii/placa/A123456` → debe responder datos del Toyota Corolla
3. `GET /api/mock/pgr/antecedentes/001-0000001-0` → debe responder tiene_antecedentes false
4. `GET /api/mock/intrant/licencia/001-0000001-0` → debe responder vigente true
5. `POST /api/v1/actas` sin token → debe responder 401
6. `POST /pagos/procesar` con datos válidos → debe responder 200 con numero_transaccion

## Problemas Comunes
- **Error 26 SQL Server**: Habilitar TCP/IP en SQL Server Configuration Manager y reiniciar el servicio.
- **Puerto 6001 ocupado**: En `Properties/launchSettings.json`, cambiar la propiedad `applicationUrl`.
- **JWT null ArgumentNullException**: Verificar que `Jwt.SecretKey` no esté vacío en `appsettings.Development.json`.
- **Failed to fetch en Swagger**: El proyecto no está corriendo. Ejecutar `dotnet run` primero.
