using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace CajaAmet
{
    public class InfraccionItem
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Particular { get; set; }
        public double Motocicleta { get; set; }
        public double Carga { get; set; }
        public bool RequiereRetencion { get; set; }

        public override string ToString()
        {
            return $"[{Codigo}] {Descripcion}";
        }
    }

    public partial class HandheldForm : Form
    {
        private string emailAgente;
        private string connectionString;
        private List<InfraccionItem> listaInfracciones = new List<InfraccionItem>();
        private string evidenciaRutaSimulada = "";
        private bool firmado = false;
        private string timestampFirma = "";

        public HandheldForm(string email, string password)
        {
            InitializeComponent();
            this.emailAgente = email;

            // Derivar clave de base de datos cifrada
            string claveHex = DatabaseManager.DerivarClave(password);
            this.connectionString = DatabaseManager.ObtenerConnectionString(claveHex);
        }

        private void HandheldForm_Load(object sender, EventArgs e)
        {
            lblAgent.Text = $"Agente: {emailAgente}";
            lblDevice.Text = "Disp: HW-DIGE-7493";
            
            // Inicializar comboboxes
            cmbTipoVehiculo.Items.Clear();
            cmbTipoVehiculo.Items.Add("Particular (Carro/Jeepeta)");
            cmbTipoVehiculo.Items.Add("Motocicleta / Pasola");
            cmbTipoVehiculo.Items.Add("Carga / Autobús");
            cmbTipoVehiculo.SelectedIndex = 0;

            // Cargar datos
            CargarCatalogoInfracciones();
            CargarHistorialActas();
            VerificarRed();

            // Panel inicial
            MostrarPanel(pnlNuevaActa, btnTabNueva);

            // Generar ID de acta inicial
            GenerarNuevoIdActa();
        }

        private void GenerarNuevoIdActa()
        {
            Random r = new Random();
            txtIdActa.Text = $"ACTA-2026-{r.Next(1000, 9999)}";
            firmado = false;
            timestampFirma = "";
            lblFirmaStatus.Text = "Firma: PENDIENTE";
            lblFirmaStatus.ForeColor = Color.FromArgb(239, 68, 68);
            evidenciaRutaSimulada = "";
            picEvidencia.Image = null;
            picEvidencia.BackColor = Color.FromArgb(30, 41, 59);
        }

        private void VerificarRed()
        {
            try
            {
                bool hayRed = NetworkInterface.GetIsNetworkAvailable();
                if (hayRed)
                {
                    lblNetworkDot.ForeColor = Color.FromArgb(74, 222, 128); // Green
                    lblNetworkText.Text = "En Línea (3G/4G)";
                    lblNetworkText.ForeColor = Color.White;
                }
                else
                {
                    lblNetworkDot.ForeColor = Color.FromArgb(239, 68, 68); // Red
                    lblNetworkText.Text = "Sin Red (Modo Offline)";
                    lblNetworkText.ForeColor = Color.FromArgb(254, 226, 226);
                }
            }
            catch
            {
                lblNetworkDot.ForeColor = Color.FromArgb(245, 158, 11); // Amber
                lblNetworkText.Text = "Red no disponible";
            }
        }

        private void timerNetwork_Tick(object sender, EventArgs e)
        {
            VerificarRed();
        }

        private void CargarCatalogoInfracciones()
        {
            listaInfracciones.Clear();
            cmbInfraccion.Items.Clear();

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT codigo, descripcion, categoria, monto_particular, monto_motocicleta, monto_carga, requiere_retencion FROM Infracciones_Cache ORDER BY codigo;";
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            dgvCatalogo.DataSource = dt;

                            // Formatear columnas del DataGridView del catálogo
                            if (dgvCatalogo.Columns.Count > 0)
                            {
                                dgvCatalogo.Columns["codigo"].HeaderText = "Código";
                                dgvCatalogo.Columns["descripcion"].HeaderText = "Descripción";
                                dgvCatalogo.Columns["categoria"].HeaderText = "Categoría";
                                dgvCatalogo.Columns["monto_particular"].HeaderText = "Particular (RD$)";
                                dgvCatalogo.Columns["monto_motocicleta"].HeaderText = "Moto (RD$)";
                                dgvCatalogo.Columns["monto_carga"].HeaderText = "Carga (RD$)";
                                dgvCatalogo.Columns["requiere_retencion"].HeaderText = "Retiene?";
                            }

                            // Volver a leer para el ComboBox
                            foreach (DataRow row in dt.Rows)
                            {
                                var item = new InfraccionItem
                                {
                                    Codigo = row["codigo"].ToString(),
                                    Descripcion = row["descripcion"].ToString(),
                                    Particular = Convert.ToDouble(row["monto_particular"]),
                                    Motocicleta = Convert.ToDouble(row["monto_motocicleta"]),
                                    Carga = Convert.ToDouble(row["monto_carga"]),
                                    RequiereRetencion = Convert.ToInt32(row["requiere_retencion"]) == 1
                                };
                                listaInfracciones.Add(item);
                                cmbInfraccion.Items.Add(item);
                            }
                        }
                    }
                }

                if (cmbInfraccion.Items.Count > 0)
                {
                    cmbInfraccion.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar catálogo de infracciones: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorialActas()
        {
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            SELECT id, conductor_cedula, conductor_nombre, tipo_infraccion_codigo, monto_base, placa, requiere_retencion, estado_sync, fecha_hecho 
                            FROM Borradores_Actas 
                            ORDER BY fecha_hecho DESC;";
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dgvActas.DataSource = dt;

                            if (dgvActas.Columns.Count > 0)
                            {
                                dgvActas.Columns["id"].HeaderText = "ID Acta";
                                dgvActas.Columns["conductor_cedula"].HeaderText = "Cédula";
                                dgvActas.Columns["conductor_nombre"].HeaderText = "Conductor";
                                dgvActas.Columns["tipo_infraccion_codigo"].HeaderText = "Infracción";
                                dgvActas.Columns["monto_base"].HeaderText = "Monto (RD$)";
                                dgvActas.Columns["placa"].HeaderText = "Placa";
                                dgvActas.Columns["requiere_retencion"].HeaderText = "Retiene?";
                                dgvActas.Columns["estado_sync"].HeaderText = "Sync";
                                dgvActas.Columns["fecha_hecho"].HeaderText = "Fecha/Hora";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial de actas: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarPanel(Panel targetPanel, Button activeTabButton)
        {
            pnlNuevaActa.Visible = false;
            pnlHistorial.Visible = false;
            pnlCatalogo.Visible = false;

            btnTabNueva.BackColor = Color.FromArgb(30, 41, 59);
            btnTabHistorial.BackColor = Color.FromArgb(30, 41, 59);
            btnTabCatalogo.BackColor = Color.FromArgb(30, 41, 59);

            targetPanel.Visible = true;
            activeTabButton.BackColor = Color.FromArgb(15, 118, 110); // Active color
        }

        private void btnTabNueva_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnlNuevaActa, btnTabNueva);
        }

        private void btnTabHistorial_Click(object sender, EventArgs e)
        {
            CargarHistorialActas();
            MostrarPanel(pnlHistorial, btnTabHistorial);
        }

        private void btnTabCatalogo_Click(object sender, EventArgs e)
        {
            CargarCatalogoInfracciones();
            MostrarPanel(pnlCatalogo, btnTabCatalogo);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActualizarMontoBase()
        {
            if (cmbInfraccion.SelectedItem == null) return;
            var inf = (InfraccionItem)cmbInfraccion.SelectedItem;
            
            double monto = 0;
            int vehTypeIndex = cmbTipoVehiculo.SelectedIndex;
            if (vehTypeIndex == 0) // Particular
                monto = inf.Particular;
            else if (vehTypeIndex == 1) // Moto
                monto = inf.Motocicleta;
            else if (vehTypeIndex == 2) // Carga
                monto = inf.Carga;

            lblMontoBaseValue.Text = $"RD$ {monto:N2}";
            
            // Auto check retención if required by infraction
            chkRetencion.Checked = inf.RequiereRetencion;
        }

        private void cmbInfraccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarMontoBase();
        }

        private void cmbTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarMontoBase();
        }

        private void chkRetencion_CheckedChanged(object sender, EventArgs e)
        {
            txtGrua.Enabled = chkRetencion.Checked;
            if (!chkRetencion.Checked)
            {
                txtGrua.Text = "";
            }
            else if (string.IsNullOrEmpty(txtGrua.Text))
            {
                Random r = new Random();
                txtGrua.Text = $"GRU-{r.Next(100, 999)}";
            }
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            // Simular toma de fotografía de evidencia
            Random r = new Random();
            string[] sceneDescriptions = {
                "Semáforo rojo e intersección cruzada",
                "Vehículo estacionado sobre acera peatonal",
                "Motociclista conduciendo en vía contraria y sin casco",
                "Conductor con dispositivo móvil en mano al conducir",
                "Giro prohibido a la izquierda obstruyendo carril rápido"
            };

            int randomIdx = r.Next(sceneDescriptions.Length);
            string desc = sceneDescriptions[randomIdx];
            
            evidenciaRutaSimulada = $"https://evidencia.digesett.gob.do/uploads/EVI-2026-{r.Next(1000, 9999)}.jpg";

            // Crear un bitmap simulado para mostrar en la pantalla
            Bitmap bmp = new Bitmap(picEvidencia.Width, picEvidencia.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(15, 118, 110));
                
                // Draw camera frame lines
                Pen whitePen = new Pen(Color.White, 2);
                g.DrawRectangle(whitePen, 10, 10, bmp.Width - 20, bmp.Height - 20);
                
                // Draw crosshair
                g.DrawLine(whitePen, bmp.Width / 2 - 10, bmp.Height / 2, bmp.Width / 2 + 10, bmp.Height / 2);
                g.DrawLine(whitePen, bmp.Width / 2, bmp.Height / 2 - 10, bmp.Width / 2, bmp.Height / 2 + 10);
                
                // Draw text label
                using (Font font = new Font("Segoe UI", 9, FontStyle.Bold))
                {
                    g.DrawString("FOTOGRAFÍA CAPTURADA", font, Brushes.White, 15, 15);
                }
                
                using (Font fontSub = new Font("Segoe UI", 8, FontStyle.Italic))
                {
                    g.DrawString($"Evi: {desc}\nUrl: {evidenciaRutaSimulada.Substring(0, 30)}...", fontSub, Brushes.LightYellow, 15, bmp.Height - 45);
                }
            }

            picEvidencia.Image = bmp;
            MessageBox.Show($"¡Fotografía de evidencia capturada con éxito!\n\nObjeto detectado: {desc}\nRuta: {evidenciaRutaSimulada}", "Cámara Handheld", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFirmar_Click(object sender, EventArgs e)
        {
            firmado = true;
            timestampFirma = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            lblFirmaStatus.Text = $"Firma: CAPTURADA ({DateTime.Now.ToString("HH:mm:ss")})";
            lblFirmaStatus.ForeColor = Color.FromArgb(74, 222, 128); // Green
            MessageBox.Show("Firma digital del conductor capturada exitosamente mediante pantalla táctil.", "Firma Digital", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string id = txtIdActa.Text.Trim();
            string cedula = txtCedula.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string placa = txtPlaca.Text.Trim();
            string descVehiculo = txtDescripcionVehiculo.Text.Trim();
            
            if (cmbInfraccion.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una infracción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var inf = (InfraccionItem)cmbInfraccion.SelectedItem;

            // Determinar monto según tipo vehículo
            double monto = 0;
            int vehTypeIndex = cmbTipoVehiculo.SelectedIndex;
            if (vehTypeIndex == 0) monto = inf.Particular;
            else if (vehTypeIndex == 1) monto = inf.Motocicleta;
            else if (vehTypeIndex == 2) monto = inf.Carga;

            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, complete los datos del infractor (Cédula y Nombre).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(placa))
            {
                MessageBox.Show("Por favor, ingrese el número de placa o escriba 'N/A' si no aplica.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkRetencion.Checked && string.IsNullOrEmpty(txtGrua.Text.Trim()))
            {
                MessageBox.Show("Dado que requiere retención, debe asignar un número de grúa.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!firmado)
            {
                var signResult = MessageBox.Show(
                    "El conductor no ha firmado la recepción del acta digital.\n¿Desea registrarla de todas formas (Se marcará como CONDUCTOR SE NIEGA A FIRMAR)?",
                    "Firma Requerida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (signResult == DialogResult.No)
                {
                    return;
                }
                timestampFirma = "SE NIEGA A FIRMAR";
            }

            try
            {
                string fechaHecho = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            INSERT INTO Borradores_Actas (id, conductor_cedula, conductor_nombre, tipo_infraccion_codigo, tipo_infraccion_desc, monto_base, placa, url_evidencia, descripcion_vehiculo, requiere_retencion, grua_numero, fecha_hecho, agente_id, estado_sync, timestamp_firma)
                            VALUES (@id, @cedula, @nombre, @codInfr, @descInfr, @monto, @placa, @evidencia, @descVeh, @reqRet, @grua, @fecha, @agente, 'PENDIENTE', @firma);";
                        
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@cedula", cedula);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@codInfr", inf.Codigo);
                        cmd.Parameters.AddWithValue("@descInfr", inf.Descripcion);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@placa", placa);
                        cmd.Parameters.AddWithValue("@evidencia", string.IsNullOrEmpty(evidenciaRutaSimulada) ? "N/A" : evidenciaRutaSimulada);
                        cmd.Parameters.AddWithValue("@descVeh", string.IsNullOrEmpty(descVehiculo) ? "N/A" : descVehiculo);
                        cmd.Parameters.AddWithValue("@reqRet", chkRetencion.Checked ? 1 : 0);
                        cmd.Parameters.AddWithValue("@grua", chkRetencion.Checked ? txtGrua.Text.Trim() : "");
                        cmd.Parameters.AddWithValue("@fecha", fechaHecho);
                        cmd.Parameters.AddWithValue("@agente", emailAgente);
                        cmd.Parameters.AddWithValue("@firma", timestampFirma);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"¡Acta registrada de forma local en el dispositivo!\n\nID: {id}\nConductor: {nombre}\nTotal: RD$ {monto:N2}\n\nEl registro se encuentra PENDIENTE de sincronización a la base de datos central.", "Acta Guardada (Offline)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Limpiar formulario y generar nuevo ID
                txtCedula.Text = "";
                txtNombre.Text = "";
                txtPlaca.Text = "";
                txtDescripcionVehiculo.Text = "";
                txtGrua.Text = "";
                GenerarNuevoIdActa();
                CargarHistorialActas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar acta en la base de datos local: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                List<(string id, string cedula, string nombre, string codInfr, string descInfr, double monto, string placa, string evidencia, string descVeh, bool reqRet, string grua, string fecha, string agente, string firma)> pendientes = new List<(string, string, string, string, string, double, string, string, string, bool, string, string, string, string)>();

                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT id, conductor_cedula, conductor_nombre, tipo_infraccion_codigo, tipo_infraccion_desc, monto_base, placa, url_evidencia, descripcion_vehiculo, requiere_retencion, grua_numero, fecha_hecho, agente_id, timestamp_firma FROM Borradores_Actas WHERE estado_sync = 'PENDIENTE';";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pendientes.Add((
                                    reader.GetString(0),
                                    reader.IsDBNull(1) ? "" : reader.GetString(1),
                                    reader.IsDBNull(2) ? "" : reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetString(4),
                                    reader.GetDouble(5),
                                    reader.IsDBNull(6) ? "" : reader.GetString(6),
                                    reader.IsDBNull(7) ? "" : reader.GetString(7),
                                    reader.IsDBNull(8) ? "" : reader.GetString(8),
                                    reader.GetInt32(9) == 1,
                                    reader.IsDBNull(10) ? "" : reader.GetString(10),
                                    reader.GetString(11),
                                    reader.GetString(12),
                                    reader.IsDBNull(13) ? "" : reader.GetString(13)
                                ));
                            }
                        }
                    }
                }

                if (pendientes.Count == 0)
                {
                    MessageBox.Show("No hay actas pendientes de sincronización.", "Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                prgSync.Value = 0;
                prgSync.Visible = true;
                lblSyncStatus.Text = $"Sincronizando {pendientes.Count} actas...";
                lblSyncStatus.Visible = true;

                int exitosos = 0;
                int fallidos = 0;

                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri("http://localhost:5001");
                    http.Timeout = TimeSpan.FromSeconds(30);

                    for (int i = 0; i < pendientes.Count; i++)
                    {
                        var p = pendientes[i];

                        int tipoInfraccionId = 1;
                        if (!string.IsNullOrEmpty(p.codInfr) && p.codInfr.StartsWith("INF-"))
                        {
                            string numPart = p.codInfr.Substring(4);
                            int.TryParse(numPart, out tipoInfraccionId);
                        }

                        var payload = new ActaSync
                        {
                            id = p.id,
                            conductorId = p.cedula,
                            tipoInfraccionId = tipoInfraccionId,
                            agenteId = p.agente,
                            placa = p.placa,
                            estado = "PENDIENTE",
                            montoBase = p.monto,
                            montoRecargo = p.monto * 0.10,
                            fechaHecho = p.fecha,
                            fechaEmision = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                            fechaLimitePago = DateTime.Now.AddDays(30).ToString("yyyy-MM-ddTHH:mm:ss"),
                            urlEvidencia = p.evidencia,
                            requiereRetencion = p.reqRet,
                            gruaNumero = p.grua,
                            identificacionPendiente = string.IsNullOrEmpty(p.nombre) || p.nombre == "PENDIENTE"
                        };

                        var json = System.Text.Json.JsonSerializer.Serialize(payload);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        try
                        {
                            var response = await http.PostAsync("/api/v1/actas/sync", content);
                            if (response.IsSuccessStatusCode)
                            {
                                exitosos++;
                                using (var conn = new SqliteConnection(connectionString))
                                {
                                    conn.Open();
                                    using (var cmd = conn.CreateCommand())
                                    {
                                        cmd.CommandText = "UPDATE Borradores_Actas SET estado_sync = 'SINCRONIZADO' WHERE id = @id;";
                                        cmd.Parameters.AddWithValue("@id", p.id);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                fallidos++;
                                string errorBody = await response.Content.ReadAsStringAsync();
                                using (var conn = new SqliteConnection(connectionString))
                                {
                                    conn.Open();
                                    using (var cmd = conn.CreateCommand())
                                    {
                                        cmd.CommandText = "UPDATE Borradores_Actas SET estado_sync = 'ERROR', error_detalle = @err WHERE id = @id;";
                                        cmd.Parameters.AddWithValue("@err", $"HTTP {(int)response.StatusCode}: {errorBody}");
                                        cmd.Parameters.AddWithValue("@id", p.id);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            fallidos++;
                            using (var conn = new SqliteConnection(connectionString))
                            {
                                conn.Open();
                                using (var cmd = conn.CreateCommand())
                                {
                                    cmd.CommandText = "UPDATE Borradores_Actas SET estado_sync = 'ERROR', error_detalle = @err WHERE id = @id;";
                                    cmd.Parameters.AddWithValue("@err", ex.Message);
                                    cmd.Parameters.AddWithValue("@id", p.id);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        prgSync.Value = (int)((i + 1) * 100.0 / pendientes.Count);
                        lblSyncStatus.Text = $"Sincronizando... {exitosos} ok, {fallidos} err";
                        Application.DoEvents();
                    }
                }

                lblSyncStatus.Text = $"Sync: {exitosos} exitosos, {fallidos} fallidos";
                MessageBox.Show($"Sincronización finalizada.\n\nExitosos: {exitosos}\nFallidos: {fallidos}", "Sync Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                prgSync.Visible = false;
                lblSyncStatus.Visible = false;
                CargarHistorialActas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de sincronización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeedPruebas_Click(object sender, EventArgs e)
        {
            // Crear registros prueba para probar funcionamiento
            try
            {
                Random r = new Random();
                var conductoresPrueba = new[]
                {
                    new { Cedula = "002-3948503-4", Nombre = "Fernando Castillo Reyes", Placa = "A839485", Desc = "Honda Civic 2012 Azul", Infr = "INF-03", Monto = 4000.0, ReqRet = 0 },
                    new { Cedula = "402-1029384-9", Nombre = "Gabriela Martínez Sosa", Placa = "X394850", Desc = "Kia Picanto 2020 Rojo", Infr = "INF-02", Monto = 3500.0, ReqRet = 0 },
                    new { Cedula = "001-9988776-5", Nombre = "Julio César de León", Placa = "L948372", Desc = "Camión Daihatsu 2005 Rojo", Infr = "INF-04", Monto = 15000.0, ReqRet = 1 }
                };

                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        foreach (var cond in conductoresPrueba)
                        {
                            string id = $"ACTA-2026-{r.Next(1000, 9999)}";
                            string fecha = DateTime.Now.AddMinutes(-r.Next(5, 120)).ToString("yyyy-MM-dd HH:mm:ss");
                            string grua = cond.ReqRet == 1 ? $"GRU-{r.Next(100, 999)}" : "";

                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.Transaction = transaction;
                                cmd.CommandText = @"
                                    INSERT INTO Borradores_Actas (id, conductor_cedula, conductor_nombre, tipo_infraccion_codigo, tipo_infraccion_desc, monto_base, placa, url_evidencia, descripcion_vehiculo, requiere_retencion, grua_numero, fecha_hecho, agente_id, estado_sync, timestamp_firma)
                                    VALUES (@id, @cedula, @nombre, @codInfr, (SELECT descripcion FROM Infracciones_Cache WHERE codigo=@codInfr), @monto, @placa, 'https://evidencia.digesett.gob.do/uploads/mock-seed.jpg', @descVeh, @reqRet, @grua, @fecha, @agente, 'PENDIENTE', 'FIRMADO_MOCK_DISPOSITIVO');";
                                
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.Parameters.AddWithValue("@cedula", cond.Cedula);
                                cmd.Parameters.AddWithValue("@nombre", cond.Nombre);
                                cmd.Parameters.AddWithValue("@codInfr", cond.Infr);
                                cmd.Parameters.AddWithValue("@monto", cond.Monto);
                                cmd.Parameters.AddWithValue("@placa", cond.Placa);
                                cmd.Parameters.AddWithValue("@descVeh", cond.Desc);
                                cmd.Parameters.AddWithValue("@reqRet", cond.ReqRet);
                                cmd.Parameters.AddWithValue("@grua", grua);
                                cmd.Parameters.AddWithValue("@fecha", fecha);
                                cmd.Parameters.AddWithValue("@agente", emailAgente);

                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                }

                MessageBox.Show("Se agregaron 3 registros de prueba con estado 'PENDIENTE' al historial del dispositivo.", "Registros Prueba", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarHistorialActas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar registros prueba: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
