using System;
<<<<<<< Updated upstream
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
=======
using System.Data;
using System.Drawing;
>>>>>>> Stashed changes
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace CajaAmet
{
    public partial class CajaForm : Form
    {
<<<<<<< Updated upstream
        private string emailCajero;
        private string connectionString;
        
        // Session state
        private bool isCajaOpen = false;
        private double openingBalance = 0.0;
        private string openingTime = "";
        
        // Active payment details
        private string activeActaUuid = "";
        private string activeConductorName = "";
        private string activeConductorCedula = "";
        private string activeInfraccion = "";
        private string activePlaca = "";
        private double activeMontoBase = 0.0;
        private double activeMora = 0.0;
        private double activeCanodromo = 0.0;
        private double activeMontoTotal = 0.0;

        public CajaForm(string email, string password)
        {
            InitializeComponent();
            this.emailCajero = email;
            
            // Derivar clave para la base de datos sqlite local cifrada
            string claveHex = DatabaseManager.DerivarClave(password);
            this.connectionString = DatabaseManager.ObtenerConnectionString(claveHex);
=======
        private string cashierId;
        private string connectionString;
        private string selectedActaUuid = null;
        private double selectedMonto = 0.0;
        private string selectedConductor = "";

        public CajaForm(string cashierId, string connectionString)
        {
            InitializeComponent();
            this.cashierId = cashierId;
            this.connectionString = connectionString;

            lblCajero.Text = $"Cajero ID: {this.cashierId}";
            ConfigurarColumnasGrid();
        }

        private void ConfigurarColumnasGrid()
        {
            dgvActas.AutoGenerateColumns = false;
            dgvActas.Columns.Clear();

            dgvActas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id",
                HeaderText = "UUID Acta",
                Name = "colId",
                Width = 80,
                ReadOnly = true
            });

            dgvActas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "conductor_cedula",
                HeaderText = "Cédula",
                Name = "colCedula",
                Width = 90,
                ReadOnly = true
            });

            dgvActas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "conductor_nombre",
                HeaderText = "Conductor",
                Name = "colNombre",
                Width = 140,
                ReadOnly = true
            });

            dgvActas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "tipo_infraccion_desc",
                HeaderText = "Infracción",
                Name = "colInfraccion",
                Width = 150,
                ReadOnly = true
            });

            dgvActas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "monto_base",
                HeaderText = "Monto",
                Name = "colMonto",
                Width = 80,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
            });

            dgvActas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "placa",
                HeaderText = "Placa",
                Name = "colPlaca",
                Width = 70,
                ReadOnly = true
            });
            
            dgvActas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "fecha_hecho",
                HeaderText = "Fecha",
                Name = "colFecha",
                Width = 110,
                ReadOnly = true
            });
>>>>>>> Stashed changes
        }

        private void CajaForm_Load(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            lblNavCajeroStatus.Text = $"Cajero:\n{emailCajero}";
            
            // Check status of Caja on startup
            VerificarEstadoCaja();
            
            // Show Apertura tab by default
            ShowPanel(pnlApertura, btnNavApertura);
        }

        private void VerificarEstadoCaja()
        {
            try
            {
=======
            CargarActasPendientes("");
            LimpiarSeleccion();
        }

        private void CargarActasPendientes(string queryText)
        {
            try
            {
                DataTable dt = new DataTable();
>>>>>>> Stashed changes
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
<<<<<<< Updated upstream
                        cmd.CommandText = @"
                            SELECT tipo, monto, timestamp, cajero_id 
                            FROM Movimientos_Caja 
                            WHERE tipo IN ('APERTURA', 'CIERRE') 
                            ORDER BY timestamp DESC, id DESC LIMIT 1;";
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string tipo = reader.GetString(0);
                                double monto = reader.GetDouble(1);
                                string timestamp = reader.GetString(2);
                                string cajero = reader.GetString(3);

                                if (tipo == "APERTURA")
                                {
                                    isCajaOpen = true;
                                    openingBalance = monto;
                                    openingTime = timestamp;
                                    
                                    lblAperturaStatus.Text = $"Estado: CAJA ABIERTA\nAbierta el: {openingTime}\nPor el cajero: {cajero}\nBalance Inicial: RD$ {openingBalance:N2}";
                                    lblAperturaStatus.ForeColor = Color.FromArgb(74, 222, 128); // Green
                                    
                                    txtMontoInicial.Enabled = false;
                                    btnAbrirCaja.Enabled = false;
                                }
                                else
                                {
                                    SetCajaCerradaUI();
                                }
                            }
                            else
                            {
                                SetCajaCerradaUI();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar el estado de la caja: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetCajaCerradaUI();
            }
        }

        private void SetCajaCerradaUI()
        {
            isCajaOpen = false;
            openingBalance = 0.0;
            openingTime = "";
            
            lblAperturaStatus.Text = "Estado: CAJA CERRADA\nDebe ingresar un balance inicial para abrir operaciones.";
            lblAperturaStatus.ForeColor = Color.FromArgb(239, 68, 68); // Red
            
            txtMontoInicial.Enabled = true;
            btnAbrirCaja.Enabled = true;
        }

        // Sidebar Navigation
        private void ShowPanel(Panel targetPanel, Button activeNavButton)
        {
            // Hide all
            pnlApertura.Visible = false;
            pnlCobro.Visible = false;
            pnlMovimientos.Visible = false;
            pnlCierre.Visible = false;

            // Reset navigation buttons colors
            btnNavApertura.BackColor = Color.FromArgb(22, 101, 52);
            btnNavCobro.BackColor = Color.FromArgb(22, 101, 52);
            btnNavMovimientos.BackColor = Color.FromArgb(22, 101, 52);
            btnNavCierre.BackColor = Color.FromArgb(22, 101, 52);

            // Set active
            targetPanel.Visible = true;
            activeNavButton.BackColor = Color.FromArgb(21, 128, 61);
            
            // Adjust sidebar indicator accent
            pnlSidebarAccent.Location = new Point(pnlSidebarAccent.Location.X, activeNavButton.Location.Y);
        }

        private bool ValidarCajaAbierta()
        {
            if (!isCajaOpen)
            {
                MessageBox.Show("Operación denegada. Debe abrir la caja (Apertura de Caja) para poder realizar esta acción.", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowPanel(pnlApertura, btnNavApertura);
                return false;
            }
            return true;
        }

        private void btnNavApertura_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlApertura, btnNavApertura);
        }

        private void btnNavCobro_Click(object sender, EventArgs e)
        {
            if (ValidarCajaAbierta())
            {
                ShowPanel(pnlCobro, btnNavCobro);
            }
        }

        private void btnNavMovimientos_Click(object sender, EventArgs e)
        {
            if (ValidarCajaAbierta())
            {
                CargarHistorialMovimientos();
                ShowPanel(pnlMovimientos, btnNavMovimientos);
            }
        }

        private void btnNavCierre_Click(object sender, EventArgs e)
        {
            if (ValidarCajaAbierta())
            {
                CalcularCuadreCaja();
                ShowPanel(pnlCierre, btnNavCierre);
            }
        }

        private void btnNavVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Logic 1: Apertura de Caja
        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            double monto;
            if (!double.TryParse(txtMontoInicial.Text.Trim(), out monto) || monto < 0)
            {
                MessageBox.Show("Por favor, ingrese un monto inicial válido.", "Monto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string timestampStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            INSERT INTO Movimientos_Caja (tipo, monto, descripcion, cajero_id, timestamp)
                            VALUES ('APERTURA', @monto, 'Apertura de turno de caja', @cajero, @timestamp);";
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@cajero", emailCajero);
                        cmd.Parameters.AddWithValue("@timestamp", timestampStr);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"¡Caja abierta exitosamente con RD$ {monto:N2}!", "Caja Abierta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerificarEstadoCaja();
                ShowPanel(pnlCobro, btnNavCobro);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la caja en base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Logic 2: Cobro de Multas
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearchQuery.Text.Trim();
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Por favor ingrese un número de cédula o UUID de acta.", "Búsqueda Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ocultar paneles mientras busca
            pnlMultaDetails.Visible = false;
            pnlRecibo.Visible = false;

            // Intentar buscar en la base de datos local Borradores_Actas
            bool multaLocalEncontrada = BuscarMultaLocal(query);
            if (multaLocalEncontrada)
            {
                CargarDetallesEnPantalla();
                return;
            }

            // Si no está local, simular consulta a la API de Yeimi o usar datos mock offline
            BuscarMultaMock(query);
            CargarDetallesEnPantalla();
        }

        private bool BuscarMultaLocal(string query)
        {
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            SELECT id, conductor_cedula, conductor_nombre, tipo_infraccion_desc, placa, fecha_hecho, monto_base
                            FROM Borradores_Actas
                            WHERE id = @query OR conductor_cedula = @query OR placa = @query
                            LIMIT 1;";
                        cmd.Parameters.AddWithValue("@query", query);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                activeActaUuid = reader.GetString(0);
                                activeConductorCedula = reader.IsDBNull(1) ? "NO IDENTIFICADO" : reader.GetString(1);
                                activeConductorName = reader.IsDBNull(2) ? "NO IDENTIFICADO" : reader.GetString(2);
                                activeInfraccion = reader.GetString(3);
                                activePlaca = reader.IsDBNull(4) ? "N/A" : reader.GetString(4);
                                string fecha = reader.GetString(5);
                                activeMontoBase = reader.GetDouble(6);
                                
                                // Calcular cargos simulados
                                activeMora = activeMontoBase * 0.10; // 10% mora
                                activeCanodromo = activePlaca != "N/A" ? 1500.00 : 0.00; // Si tiene placa, simulamos estadía
                                activeMontoTotal = activeMontoBase + activeMora + activeCanodromo;
                                
                                return true;
                            }
                        }
                    }
                }
            }
            catch
            {
                // Fallback silencioso si hay algún problema con la consulta
            }
            return false;
        }

        private void BuscarMultaMock(string query)
        {
            // Fines catalogados para testing rápido de la interfaz
            if (query == "223-0123456-7" || query.Contains("223"))
            {
                activeActaUuid = Guid.NewGuid().ToString();
                activeConductorCedula = "223-0123456-7";
                activeConductorName = "Juan Carlos Gómez";
                activeInfraccion = "Cruzar en Luz Roja (INF-02)";
                activePlaca = "A123456";
                activeMontoBase = 3500.00;
                activeMora = 350.00;
                activeCanodromo = 1500.00;
            }
            else if (query == "402-9876543-2" || query.Contains("402"))
            {
                activeActaUuid = Guid.NewGuid().ToString();
                activeConductorCedula = "402-9876543-2";
                activeConductorName = "María Almonte Rodríguez";
                activeInfraccion = "Obstrucción de Tránsito / Estacionamiento Prohibido (INF-09)";
                activePlaca = "G384950";
                activeMontoBase = 2000.00;
                activeMora = 0.00;
                activeCanodromo = 0.00;
            }
            else if (query == "001-5554433-2" || query.Contains("555"))
            {
                activeActaUuid = Guid.NewGuid().ToString();
                activeConductorCedula = "001-5554433-2";
                activeConductorName = "Pedro Antonio Martínez";
                activeInfraccion = "Conducir sin Licencia o Vencida (INF-01)";
                activePlaca = "N849503";
                activeMontoBase = 5000.00;
                activeMora = 1000.00;
                activeCanodromo = 4500.00; // 15 días canódromo
            }
            else
            {
                // Registro por defecto autogenerado para cualquier otro valor
                activeActaUuid = Guid.NewGuid().ToString();
                activeConductorCedula = query;
                activeConductorName = "Conductor Evaluador (MOCK)";
                activeInfraccion = "Infracción General de Tránsito (INF-99)";
                activePlaca = "PROB-2026";
                activeMontoBase = 1000.00;
                activeMora = 100.00;
                activeCanodromo = 0.00;
            }

            activeMontoTotal = activeMontoBase + activeMora + activeCanodromo;
        }

        private void CargarDetallesEnPantalla()
        {
            lblDetConductor.Text = $"Conductor: {activeConductorName}";
            lblDetCedula.Text = $"Cédula: {activeConductorCedula}";
            lblDetInfraccion.Text = $"Infracción: {activeInfraccion}";
            lblDetPlaca.Text = $"Placa: {activePlaca}";
            
            lblBreakdownBase.Text =      $"Multa Base: ........ RD$ {activeMontoBase:N2}";
            lblBreakdownMora.Text =      $"Recargo por Mora: .. RD$ {activeMora:N2}";
            lblBreakdownCanodromo.Text = $"Estadía Canódromo: RD$ {activeCanodromo:N2}";
            lblBreakdownTotal.Text =     $"Total a Cobrar: ...... RD$ {activeMontoTotal:N2}";
            
            cmbMetodoPago.SelectedIndex = 0; // Efectivo por defecto
            txtMontoRecibido.Text = activeMontoTotal.ToString("F2");
            ActualizarCambioDeEfectivo();

            pnlMultaDetails.Visible = true;
        }

        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodoPago.SelectedIndex == 1) // Tarjeta
            {
                txtMontoRecibido.Enabled = false;
                txtMontoRecibido.Text = activeMontoTotal.ToString("F2");
                lblCambioValor.Text = "RD$ 0.00 (Pago con Tarjeta)";
            }
            else // Efectivo
            {
                txtMontoRecibido.Enabled = true;
                ActualizarCambioDeEfectivo();
            }
        }

        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            ActualizarCambioDeEfectivo();
        }

        private void ActualizarCambioDeEfectivo()
        {
            if (cmbMetodoPago.SelectedIndex == 1) return; // Card payment

            double recibido;
            if (double.TryParse(txtMontoRecibido.Text.Trim(), out recibido))
            {
                double cambio = recibido - activeMontoTotal;
                if (cambio >= 0)
                {
                    lblCambioValor.Text = $"RD$ {cambio:N2}";
                    lblCambioValor.ForeColor = Color.FromArgb(74, 222, 128); // Green
                    btnProcesarPago.Enabled = true;
                }
                else
                {
                    lblCambioValor.Text = "Efectivo insuficiente";
                    lblCambioValor.ForeColor = Color.FromArgb(239, 68, 68); // Red
                    btnProcesarPago.Enabled = false;
                }
            }
            else
            {
                lblCambioValor.Text = "Monto recibido inválido";
                lblCambioValor.ForeColor = Color.FromArgb(239, 68, 68);
                btnProcesarPago.Enabled = false;
            }
        }

        private async void btnProcesarPago_Click(object sender, EventArgs e)
        {
            // Registrar pago
            btnProcesarPago.Enabled = false;
            
            // Simular retraso de procesamiento para darle realismo
            lblCambioValor.Text = "Procesando pago de forma segura...";
            await Task.Delay(1200);

            string trNum = "TRX-" + new Random().Next(100000, 999999) + "-DIGESETT";
            string metodoPago = cmbMetodoPago.SelectedItem.ToString();
            string timestampStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            INSERT INTO Movimientos_Caja (tipo, monto, descripcion, acta_uuid, cajero_id, timestamp)
                            VALUES ('COBRO_MULTA', @monto, @desc, @acta, @cajero, @timestamp);";
                        cmd.Parameters.AddWithValue("@monto", activeMontoTotal);
                        cmd.Parameters.AddWithValue("@desc", $"Cobro de multa {activeInfraccion} - {metodoPago} ({trNum})");
                        cmd.Parameters.AddWithValue("@acta", activeActaUuid);
                        cmd.Parameters.AddWithValue("@cajero", emailCajero);
                        cmd.Parameters.AddWithValue("@timestamp", timestampStr);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Generar el tique de recibo oficial
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("=========================================");
                sb.AppendLine("        DIRECCION GENERAL DE SEGURIDAD   ");
                sb.AppendLine("      DE TRANSITO Y TRANSPORTE TERRESTRE ");
                sb.AppendLine("                 (DIGESETT)              ");
                sb.AppendLine("=========================================");
                sb.AppendLine($"FECHA COBRO: {timestampStr}");
                sb.AppendLine($"CAJERO:      {emailCajero}");
                sb.AppendLine($"TRANSACCION: {trNum}");
                sb.AppendLine($"CANAL:       VENTANILLA (CAJA)");
                sb.AppendLine("-----------------------------------------");
                sb.AppendLine($"ACTA UUID:   {activeActaUuid}");
                sb.AppendLine($"CONDUCTOR:   {activeConductorName}");
                sb.AppendLine($"CEDULA:      {activeConductorCedula}");
                sb.AppendLine($"PLACA:       {activePlaca}");
                sb.AppendLine($"INFRACCION:  {activeInfraccion}");
                sb.AppendLine("-----------------------------------------");
                sb.AppendLine($"MULTA BASE:          RD$ {activeMontoBase:N2}");
                sb.AppendLine($"RECARGO MORA:        RD$ {activeMora:N2}");
                sb.AppendLine($"ESTADIA CANODROMO:   RD$ {activeCanodromo:N2}");
                sb.AppendLine("-----------------------------------------");
                sb.AppendLine($"TOTAL COBRADO:       RD$ {activeMontoTotal:N2}");
                sb.AppendLine($"METODO PAGO:         {metodoPago}");
                if (metodoPago == "EFECTIVO")
                {
                    double recibido = double.Parse(txtMontoRecibido.Text.Trim());
                    sb.AppendLine($"EFECTIVO RECIBIDO:   RD$ {recibido:N2}");
                    sb.AppendLine($"CAMBIO ENTREGADO:    RD$ {(recibido - activeMontoTotal):N2}");
                }
                sb.AppendLine("=========================================");
                sb.AppendLine("      ¡PAGO PROCESADO Y CONSOLIDADO!     ");
                sb.AppendLine("  Este tique representa el recibo oficial");
                sb.AppendLine("  de descargo de la infracción en el Core ");
                sb.AppendLine("=========================================");
                
                txtReciboDetalle.Text = sb.ToString();
                
                // Show recibo sub-panel
                pnlRecibo.Visible = true;
                pnlMultaDetails.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar transacción: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnProcesarPago.Enabled = true;
            }
        }

        private void btnPrintRecibo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Enviando documento a la cola de impresión...\n\n[IMPRESION SIMULADA]: El documento de pago ha sido formateado correctamente para el formato de tique estándar (80mm) y se ha enviado la señal de impresión física.",
                "Impresora de Caja",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnNuevaBusqueda_Click(object sender, EventArgs e)
        {
            txtSearchQuery.Text = "";
            pnlRecibo.Visible = false;
            txtSearchQuery.Focus();
        }

        // Logic 3: Entradas / Salidas
        private void CargarHistorialMovimientos()
        {
            lstMovimientos.Items.Clear();
            cmbMovType.SelectedIndex = 0;
            txtMovMonto.Text = "";
            txtMovDesc.Text = "";

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            SELECT tipo, monto, descripcion, timestamp 
                            FROM Movimientos_Caja 
                            WHERE timestamp >= @openingTime 
                            ORDER BY id DESC;";
                        cmd.Parameters.AddWithValue("@openingTime", openingTime);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tipo = reader.GetString(0);
                                double monto = reader.GetDouble(1);
                                string desc = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                string timestamp = reader.GetString(3);

                                string item = $"[{timestamp}] {tipo} - RD$ {monto:N2} | {desc}";
                                lstMovimientos.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar movimientos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarMov_Click(object sender, EventArgs e)
        {
            double monto;
            if (!double.TryParse(txtMovMonto.Text.Trim(), out monto) || monto <= 0)
            {
                MessageBox.Show("Por favor, ingrese un monto válido mayor a cero.", "Monto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string desc = txtMovDesc.Text.Trim();
            if (string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Por favor, ingrese un concepto o motivo del movimiento.", "Descripción Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipo = cmbMovType.SelectedIndex == 0 ? "ENTRADA" : "SALIDA";
            string timestampStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            INSERT INTO Movimientos_Caja (tipo, monto, descripcion, cajero_id, timestamp)
                            VALUES (@tipo, @monto, @desc, @cajero, @timestamp);";
                        cmd.Parameters.AddWithValue("@tipo", tipo);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@desc", desc);
                        cmd.Parameters.AddWithValue("@cajero", emailCajero);
                        cmd.Parameters.AddWithValue("@timestamp", timestampStr);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Movimiento de {tipo} registrado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarHistorialMovimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar movimiento: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Logic 4: Cierre de Caja
        private double calculatedExpectedTotal = 0.0;

        private void CalcularCuadreCaja()
        {
            double totalCobros = 0;
            double totalEntradas = 0;
            double totalSalidas = 0;

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    
                    // Sum COBRO_MULTA
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT SUM(monto) FROM Movimientos_Caja WHERE tipo = 'COBRO_MULTA' AND timestamp >= @openingTime;";
                        cmd.Parameters.AddWithValue("@openingTime", openingTime);
                        var val = cmd.ExecuteScalar();
                        totalCobros = val == DBNull.Value || val == null ? 0 : Convert.ToDouble(val);
                    }

                    // Sum ENTRADA
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT SUM(monto) FROM Movimientos_Caja WHERE tipo = 'ENTRADA' AND timestamp >= @openingTime;";
                        cmd.Parameters.AddWithValue("@openingTime", openingTime);
                        var val = cmd.ExecuteScalar();
                        totalEntradas = val == DBNull.Value || val == null ? 0 : Convert.ToDouble(val);
                    }

                    // Sum SALIDA
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT SUM(monto) FROM Movimientos_Caja WHERE tipo = 'SALIDA' AND timestamp >= @openingTime;";
                        cmd.Parameters.AddWithValue("@openingTime", openingTime);
                        var val = cmd.ExecuteScalar();
                        totalSalidas = val == DBNull.Value || val == null ? 0 : Convert.ToDouble(val);
                    }
                }

                calculatedExpectedTotal = openingBalance + totalCobros + totalEntradas - totalSalidas;

                // Load to UI labels
                lblCierreAperturaValor.Text = $"RD$ {openingBalance:N2}";
                lblCierreCobrosValor.Text = $"RD$ {totalCobros:N2}";
                lblCierreEntradasValor.Text = $"RD$ {totalEntradas:N2}";
                lblCierreSalidasValor.Text = $"RD$ {totalSalidas:N2}";
                lblCierreTotalEsperadoValor.Text = $"RD$ {calculatedExpectedTotal:N2}";

                txtCierreConteoFisico.Text = calculatedExpectedTotal.ToString("F2");
                CalcularDiferenciaCierre();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular cuadre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCierreConteoFisico_TextChanged(object sender, EventArgs e)
        {
            CalcularDiferenciaCierre();
        }

        private void CalcularDiferenciaCierre()
        {
            double real;
            if (double.TryParse(txtCierreConteoFisico.Text.Trim(), out real))
            {
                double diff = real - calculatedExpectedTotal;
                if (Math.Abs(diff) < 0.01)
                {
                    lblCierreDiferenciaValor.Text = "RD$ 0.00 (Cuadre Perfecto)";
                    lblCierreDiferenciaValor.ForeColor = Color.FromArgb(74, 222, 128); // Green
                }
                else if (diff > 0)
                {
                    lblCierreDiferenciaValor.Text = $"+RD$ {diff:N2} (Sobrante)";
                    lblCierreDiferenciaValor.ForeColor = Color.FromArgb(245, 158, 11); // Amber
                }
                else
                {
                    lblCierreDiferenciaValor.Text = $"-RD$ {Math.Abs(diff):N2} (Faltante)";
                    lblCierreDiferenciaValor.ForeColor = Color.FromArgb(239, 68, 68); // Red
                }
            }
            else
            {
                lblCierreDiferenciaValor.Text = "Monto real inválido";
                lblCierreDiferenciaValor.ForeColor = Color.FromArgb(239, 68, 68);
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            double real;
            if (!double.TryParse(txtCierreConteoFisico.Text.Trim(), out real) || real < 0)
            {
                MessageBox.Show("Por favor, ingrese un conteo físico válido.", "Monto Real Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double diff = real - calculatedExpectedTotal;
            string diffMsg = Math.Abs(diff) < 0.01 ? "Cuadre Perfecto" : (diff > 0 ? $"Sobrante de RD$ {diff:N2}" : $"Faltante de RD$ {Math.Abs(diff):N2}");
            
            var result = MessageBox.Show(
                $"¿Está seguro de cerrar el turno de caja?\n\nResumen del Cierre:\n- Saldo Esperado: RD$ {calculatedExpectedTotal:N2}\n- Conteo Físico: RD$ {real:N2}\n- Diagnóstico: {diffMsg}\n\nUna vez cerrada, no podrá registrar más cobros en este turno.",
                "Confirmación de Cierre",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes) return;

            string timestampStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
=======
                        if (string.IsNullOrEmpty(queryText))
                        {
                            cmd.CommandText = @"
                                SELECT id, conductor_cedula, conductor_nombre, tipo_infraccion_desc, monto_base, placa, fecha_hecho 
                                FROM Borradores_Actas 
                                WHERE estado_sync = 'PENDIENTE'
                                ORDER BY fecha_hecho DESC;";
                        }
                        else
                        {
                            cmd.CommandText = @"
                                SELECT id, conductor_cedula, conductor_nombre, tipo_infraccion_desc, monto_base, placa, fecha_hecho 
                                FROM Borradores_Actas 
                                WHERE estado_sync = 'PENDIENTE' 
                                  AND (conductor_cedula LIKE @q OR placa LIKE @q OR conductor_nombre LIKE @q)
                                ORDER BY fecha_hecho DESC;";
                            cmd.Parameters.AddWithValue("@q", $"%{queryText}%");
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                dgvActas.DataSource = dt;
                lblResultados.Text = $"Se encontraron {dt.Rows.Count} actas pendientes.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar actas: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarActasPendientes(txtBuscar.Text.Trim());
            LimpiarSeleccion();
        }

        private void dgvActas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvActas.SelectedRows.Count > 0)
            {
                var row = dgvActas.SelectedRows[0];
                selectedActaUuid = row.Cells["colId"].Value?.ToString();
                selectedConductor = row.Cells["colNombre"].Value?.ToString();
                
                if (double.TryParse(row.Cells["colMonto"].Value?.ToString(), out double m))
                {
                    selectedMonto = m;
                }
                else
                {
                    selectedMonto = 0.0;
                }

                lblSelectedActa.Text = $"Acta UUID: {selectedActaUuid.Substring(0, 8)}...";
                lblSelectedConductor.Text = $"Conductor: {selectedConductor}";
                lblSelectedMonto.Text = $"Monto a Pagar: RD$ {selectedMonto:N2}";
                btnPagar.Enabled = true;
                txtDescPago.Enabled = true;
            }
            else
            {
                LimpiarSeleccion();
            }
        }

        private void LimpiarSeleccion()
        {
            selectedActaUuid = null;
            selectedMonto = 0.0;
            selectedConductor = "";

            lblSelectedActa.Text = "Acta UUID: Seleccione una multa";
            lblSelectedConductor.Text = "Conductor: -";
            lblSelectedMonto.Text = "Monto a Pagar: RD$ 0.00";
            btnPagar.Enabled = false;
            txtDescPago.Enabled = false;
            txtDescPago.Clear();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedActaUuid))
            {
                MessageBox.Show("Por favor, seleccione un acta de la lista.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Confirmar cobro de RD$ {selectedMonto:N2} para el conductor {selectedConductor}?", 
                "Confirmar Transacción", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            string timestamp = DateTime.Now.ToString("o");
            string descripcionPago = string.IsNullOrEmpty(txtDescPago.Text.Trim()) 
                ? $"Cobro de multa por acta {selectedActaUuid.Substring(0, 8)}" 
                : txtDescPago.Text.Trim();
>>>>>>> Stashed changes

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
<<<<<<< Updated upstream
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            INSERT INTO Movimientos_Caja (tipo, monto, descripcion, cajero_id, timestamp)
                            VALUES ('CIERRE', @monto, @desc, @cajero, @timestamp);";
                        cmd.Parameters.AddWithValue("@monto", real);
                        cmd.Parameters.AddWithValue("@desc", $"Cierre de caja. Esperado: {calculatedExpectedTotal:N2}, Real: {real:N2}, Detalle: {diffMsg}");
                        cmd.Parameters.AddWithValue("@cajero", emailCajero);
                        cmd.Parameters.AddWithValue("@timestamp", timestampStr);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("¡Cierre de caja registrado y consolidado con éxito!\nSesión de turno terminada.", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerificarEstadoCaja();
                ShowPanel(pnlApertura, btnNavApertura);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el cierre en la base de datos: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
=======
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1. Insertar el movimiento en Movimientos_Caja
                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.Transaction = transaction;
                                cmd.CommandText = @"
                                    INSERT INTO Movimientos_Caja (tipo, monto, descripcion, acta_uuid, cajero_id, timestamp)
                                    VALUES ('ENTRADA', @monto, @desc, @actaUuid, @cajeroId, @timestamp);";

                                cmd.Parameters.AddWithValue("@monto", selectedMonto);
                                cmd.Parameters.AddWithValue("@desc", descripcionPago);
                                cmd.Parameters.AddWithValue("@actaUuid", selectedActaUuid);
                                cmd.Parameters.AddWithValue("@cajeroId", cashierId);
                                cmd.Parameters.AddWithValue("@timestamp", timestamp);

                                cmd.ExecuteNonQuery();
                            }

                            // 2. Marcar el acta como pagada
                            using (var cmd = connection.CreateCommand())
                            {
                                cmd.Transaction = transaction;
                                cmd.CommandText = @"
                                    UPDATE Borradores_Actas 
                                    SET estado_sync = 'PAGADO' 
                                    WHERE id = @actaUuid;";

                                cmd.Parameters.AddWithValue("@actaUuid", selectedActaUuid);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    $"¡Pago Procesado Exitosamente!\r\n\r\n" +
                    $"Ticket Oficial de Recibo:\r\n" +
                    $"==================================\r\n" +
                    $"Recibo de Caja: DIGESETT-RC-{DateTime.Now.Ticks.ToString().Substring(10)}\r\n" +
                    $"Conductor: {selectedConductor}\r\n" +
                    $"Monto Cobrado: RD$ {selectedMonto:N2}\r\n" +
                    $"Concepto: {descripcionPago}\r\n" +
                    $"Cajero: {cashierId}\r\n" +
                    $"Fecha/Hora: {DateTime.Now.ToString("G")}\r\n" +
                    $"==================================\r\n" +
                    $"\r\n¡Transacción registrada y base de datos local actualizada!", 
                    "Recibo de Pago de Caja", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );

                // Recargar lista y limpiar selección
                CargarActasPendientes(txtBuscar.Text.Trim());
                LimpiarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}", "Error de Transacción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
>>>>>>> Stashed changes
    }
}
