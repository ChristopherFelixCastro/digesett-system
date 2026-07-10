using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace CajaAmet
{
    public partial class HandheldForm : Form
    {
        private string agentId;
        private string connectionString;
        private List<InfraccionItem> infracciones = new List<InfraccionItem>();

        private class InfraccionItem
        {
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
            public double MontoParticular { get; set; }
            public double MontoMotocicleta { get; set; }
            public double MontoCarga { get; set; }
            public bool RequiereRetencion { get; set; }

            public override string ToString() => Descripcion;
        }

        public HandheldForm(string agentId, string connectionString)
        {
            InitializeComponent();
            this.agentId = agentId;
            this.connectionString = connectionString;
            
            lblAgente.Text = $"Agente ID: {this.agentId}";
            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void HandheldForm_Load(object sender, EventArgs e)
        {
            CargarInfracciones();
            ActualizarMontoYRetencion();
        }

        private void CargarInfracciones()
        {
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT codigo, descripcion, monto_particular, monto_motocicleta, monto_carga, requiere_retencion FROM Infracciones_Cache;";
                        using (var reader = cmd.ExecuteReader())
                        {
                            infracciones.Clear();
                            while (reader.Read())
                            {
                                infracciones.Add(new InfraccionItem
                                {
                                    Codigo = reader.GetString(0),
                                    Descripcion = reader.GetString(1),
                                    MontoParticular = reader.GetDouble(2),
                                    MontoMotocicleta = reader.GetDouble(3),
                                    MontoCarga = reader.GetDouble(4),
                                    RequiereRetencion = reader.GetInt32(5) == 1
                                });
                            }
                        }
                    }
                }

                cmbInfraccion.DataSource = null;
                cmbInfraccion.DataSource = infracciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el catálogo de infracciones: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarMontoYRetencion()
        {
            if (cmbInfraccion.SelectedItem is InfraccionItem selected)
            {
                double monto = selected.MontoParticular;
                if (rbMotocicleta.Checked)
                {
                    monto = selected.MontoMotocicleta;
                }
                else if (rbCarga.Checked)
                {
                    monto = selected.MontoCarga;
                }

                txtMonto.Text = monto.ToString("N2");
                chkRetencion.Checked = selected.RequiereRetencion;
                
                // Activar/desactivar textbox de número de grúa según la retención
                txtGrua.Enabled = selected.RequiereRetencion;
                if (!selected.RequiereRetencion)
                {
                    txtGrua.Clear();
                }
            }
        }

        private void cmbInfraccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarMontoYRetencion();
        }

        private void rbVehiculo_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarMontoYRetencion();
        }

        private void chkRetencion_CheckedChanged(object sender, EventArgs e)
        {
            txtGrua.Enabled = chkRetencion.Checked;
            if (!chkRetencion.Checked)
            {
                txtGrua.Clear();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            string cedula = txtCedula.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string placa = txtPlaca.Text.Trim();
            string descVehiculo = txtDescripcionVehiculo.Text.Trim();
            
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(placa))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios: Cédula, Nombre del Conductor y Placa.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbInfraccion.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de infracción.", "Infracción Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var infraccion = (InfraccionItem)cmbInfraccion.SelectedItem;
            
            if (chkRetencion.Checked && string.IsNullOrEmpty(txtGrua.Text.Trim()))
            {
                MessageBox.Show("Para infracciones que requieren retención de vehículo, debe ingresar el número de grúa.", "Grúa Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double monto = 0;
            double.TryParse(txtMonto.Text, out monto);

            string uuid = Guid.NewGuid().ToString();
            string fecha = DateTime.Now.ToString("o"); // Formato ISO 8601 para Sqlite

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            INSERT INTO Borradores_Actas (
                                id, conductor_cedula, conductor_nombre, tipo_infraccion_codigo, 
                                tipo_infraccion_desc, monto_base, placa, descripcion_vehiculo, 
                                requiere_retencion, grua_numero, fecha_hecho, agente_id, 
                                estado_sync, timestamp_firma
                            ) VALUES (
                                @id, @cedula, @nombre, @codigo, 
                                @desc, @monto, @placa, @descVehiculo, 
                                @retencion, @grua, @fecha, @agenteId, 
                                'PENDIENTE', @timestamp
                            );";

                        cmd.Parameters.AddWithValue("@id", uuid);
                        cmd.Parameters.AddWithValue("@cedula", cedula);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@codigo", infraccion.Codigo);
                        cmd.Parameters.AddWithValue("@desc", infraccion.Descripcion);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@placa", placa);
                        cmd.Parameters.AddWithValue("@descVehiculo", string.IsNullOrEmpty(descVehiculo) ? (object)DBNull.Value : descVehiculo);
                        cmd.Parameters.AddWithValue("@retencion", chkRetencion.Checked ? 1 : 0);
                        cmd.Parameters.AddWithValue("@grua", chkRetencion.Checked ? (object)txtGrua.Text.Trim() : DBNull.Value);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@agenteId", agentId);
                        cmd.Parameters.AddWithValue("@timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    $"Acta de infracción registrada con éxito.\n\nCódigo Acta: {uuid.Substring(0, 8)}...\nConductor: {nombre}\nTotal: RD${monto:N2}", 
                    "Acta Registrada", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );

                // Limpiar formulario para nuevo registro
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el acta: {ex.Message}", "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtPlaca.Clear();
            txtDescripcionVehiculo.Clear();
            txtGrua.Clear();
            rbParticular.Checked = true;
            if (cmbInfraccion.Items.Count > 0)
            {
                cmbInfraccion.SelectedIndex = 0;
            }
            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
