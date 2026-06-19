using System;
using System.Drawing;
using System.Windows.Forms;

namespace CajaAmet
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
            
            txtLog.AppendText(logResultado);
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
                
                // Transición al menú principal (se abre pasando credenciales)
                this.Hide();
                var menuForm = new MenuPrincipalForm(email, password);
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
