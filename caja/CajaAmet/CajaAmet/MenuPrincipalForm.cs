using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace CajaAmet
{
    public partial class MenuPrincipalForm : Form
    {
        private string emailAgente;
        private string passwordAgente;

        public MenuPrincipalForm(string email, string password)
        {
            InitializeComponent();
            this.emailAgente = email;
            this.passwordAgente = password;

            lblWelcome.Text = $"Sesión Activa: {emailAgente}";
            lblDbPath.Text = $"Base de datos cifrada: {DatabaseManager.ObtenerDbPath()}";
            
            // Chequeo inicial de red
            VerificarConectividadRed();
        }

        private void timerNetwork_Tick(object sender, EventArgs e)
        {
            VerificarConectividadRed();
        }

        private void VerificarConectividadRed()
        {
            try
            {
                bool hayRed = NetworkInterface.GetIsNetworkAvailable();
                if (hayRed)
                {
                    lblNetworkDot.ForeColor = Color.FromArgb(74, 222, 128); // Green
                    lblNetworkText.Text = "En Línea";
                    lblNetworkText.ForeColor = Color.White;
                }
                else
                {
                    lblNetworkDot.ForeColor = Color.FromArgb(239, 68, 68); // Red
                    lblNetworkText.Text = "Sin Conexión (Offline)";
                    lblNetworkText.ForeColor = Color.FromArgb(254, 226, 226); // Light Red
                }
            }
            catch
            {
                lblNetworkDot.ForeColor = Color.FromArgb(245, 158, 11); // Amber
                lblNetworkText.Text = "Red no disponible";
            }
        }

        private void btnHandheld_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Iniciando Modo Handheld (Agente de Calle)...\n\nEste módulo le permitirá registrar actas de infracción en la vía pública de manera offline-first.", 
                "Modo Handheld", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information
            );
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Iniciando Modo Caja (Ventanilla)...\n\nEste módulo le permitirá gestionar aperturas, registrar cobros de multas y emitir recibos oficiales.", 
                "Modo Caja", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information
            );
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Cerrar sesión y volver al login
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
