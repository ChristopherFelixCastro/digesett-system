using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CajaAmet
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            InitializeTestUsersComboBox();
        }

        private void InitializeTestUsersComboBox()
        {
            cmbTestUsers.Items.Clear();
            cmbTestUsers.Items.Add("— Ingresar credenciales manualmente —");
            cmbTestUsers.Items.Add("Administrador: Ing. Ángel (admin@digesett.gov.do)");
            cmbTestUsers.SelectedIndex = 1; // Select Admin by default for easy testing
        }

        private void cmbTestUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbTestUsers.SelectedIndex;
            if (index == 0) // Manual
            {
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtEmail.Focus();
            }
            else if (index == 1) // Admin
            {
                txtEmail.Text = "admin@digesett.gov.do";
                txtPassword.Text = "admin";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese el email/ID y la contraseña.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtLog.Clear();
            txtLog.AppendText("Iniciando validación de credenciales...\r\n");
            
            // Simulación de login offline/local
            txtLog.AppendText("Autenticación local exitosa.\r\n");
            txtLog.AppendText("Iniciando Prueba de Concepto (PoC) de SQLCipher...\r\n\r\n");
            
            string logResultado;
            bool exito = DatabaseManager.EjecutarPoC(password, out logResultado);

            // Guardar log en disco para inspeccionar el error exacto
            try
            {
                string baseDirLog = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "caja_poc_log.txt");
                System.IO.File.WriteAllText(baseDirLog, logResultado);
                string projectLog = @"C:\Users\angel\OneDrive\Documentos\GitHub\digesett-system\caja\CajaAmet\caja_poc_log.txt";
                System.IO.File.WriteAllText(projectLog, logResultado);
            }
            catch { }
            
            txtLog.Text = logResultado;
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();

            if (exito)
            {
                MessageBox.Show(
                    "¡Prueba de Concepto de SQLCipher completada con éxito!\n\nLa base de datos local ha sido cifrada con AES-256 mediante PBKDF2 y las tablas operativas se han inicializado correctamente.", 
                    "Éxito de Cifrado PoC", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );
                
                // Determine user role and name
                string nombre = "Usuario";
                string rol = "AGENTE";
                if (email.Equals("cajero1@digesett.gov.do", StringComparison.OrdinalIgnoreCase))
                {
                    nombre = "Juan Pérez";
                    rol = "CAJERO";
                }
                else if (email.Equals("cajero2@digesett.gov.do", StringComparison.OrdinalIgnoreCase))
                {
                    nombre = "María Rodríguez";
                    rol = "CAJERO";
                }
                else if (email.Equals("agente1@digesett.gov.do", StringComparison.OrdinalIgnoreCase))
                {
                    nombre = "Sgt. Pedro Martínez";
                    rol = "AGENTE";
                }
                else if (email.Equals("agente2@digesett.gov.do", StringComparison.OrdinalIgnoreCase))
                {
                    nombre = "Cabo Ana Gómez";
                    rol = "AGENTE";
                }
                else if (email.Equals("angel@digesett.gov.do", StringComparison.OrdinalIgnoreCase))
                {
                    nombre = "Ing. Ángel";
                    rol = "ADMIN";
                }

                // Transición al menú principal (se abre pasando credenciales)
                this.Hide();
                var menuForm = new MenuPrincipalForm(email, password, nombre, rol);
                menuForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Error durante la ejecución de la Prueba de Concepto de Cifrado. Revise el log de consola.", 
                    "Error de PoC", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
