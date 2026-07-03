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
        private string nombreAgente;
        private string rolAgente;

        public MenuPrincipalForm(string email, string password, string nombre = "Ángel", string rol = "AGENTE")
        {
            InitializeComponent();
            this.emailAgente = email;
            this.passwordAgente = password;
            this.nombreAgente = nombre;
            this.rolAgente = rol;

            lblWelcome.Text = $"Sesión Activa: {nombreAgente} ({rolAgente})";
            lblDbPath.Text = $"Base de datos cifrada: {DatabaseManager.ObtenerDbPath()}";
            
            // Adjust options colors based on role
            if (rolAgente == "CAJERO")
            {
                btnHandheld.BackColor = Color.FromArgb(71, 85, 105); // Gray out slightly to indicate it's not their main role
            }
            else if (rolAgente == "AGENTE")
            {
                btnCaja.BackColor = Color.FromArgb(71, 85, 105); // Gray out slightly to indicate it's not their main role
            }

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
            if (rolAgente == "CAJERO")
            {
                var result = MessageBox.Show(
                    "Su rol asignado es CAJERO. El Modo Handheld es para Agentes de Calle.\n¿Desea ingresar de todos modos para fines de prueba?",
                    "Aviso de Rol",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result != DialogResult.Yes) return;
            }

            MessageBox.Show(
                "Iniciando Modo Handheld (Agente de Calle)...\n\nEste módulo le permitirá registrar actas de infracción en la vía pública de manera offline-first.", 
                "Modo Handheld", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information
            );
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            if (rolAgente == "AGENTE")
            {
                var result = MessageBox.Show(
                    "Su rol asignado es AGENTE. El Modo Caja es para Cajeros de Ventanilla.\n¿Desea ingresar de todos modos para fines de prueba?",
                    "Aviso de Rol",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result != DialogResult.Yes) return;
            }

            // Abrir el módulo de Caja
            var cajaForm = new CajaForm(emailAgente, passwordAgente);
            cajaForm.ShowDialog();
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
