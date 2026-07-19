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
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese el email y la contraseña.",
                    "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtLog.Clear();
            txtLog.AppendText("Conectando con el servidor DIGESETT...\r\n");
            btnLogin.Enabled = false;

            try
            {
                // ── 1. Autenticar contra el Core via Yeimi ────────────────
                using (var http = new System.Net.Http.HttpClient())
                {
                    http.BaseAddress = new Uri("http://localhost:6001");
                    http.Timeout = TimeSpan.FromSeconds(10);

                    http.DefaultRequestHeaders.ExpectContinue = false;

                    var payload = System.Text.Json.JsonSerializer.Serialize(
                        new { email, password }
                    );
                    var content = new System.Net.Http.StringContent(
                        payload,
                        System.Text.Encoding.UTF8,
                        "application/json"
                    );

                    txtLog.AppendText("Enviando credenciales al servidor...\r\n");
                    var response = await http.PostAsync("/api/v1/auth/login", content);
                    var body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        txtLog.AppendText($"Error de autenticación: {body}\r\n");
                        MessageBox.Show(
                            "Credenciales inválidas. Verifica tu email y contraseña.",
                            "Error de Autenticación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        btnLogin.Enabled = true;
                        return;
                    }

                    // ── 2. Parsear respuesta del Core ─────────────────────
                    using var doc = System.Text.Json.JsonDocument.Parse(body);
                    var root = doc.RootElement;
                    string token = root.GetProperty("token").GetString()!;
                    string userId = root.GetProperty("id").GetString()!;
                    string nombre = root.GetProperty("nombre").GetString()!;
                    string rol = root.GetProperty("rol").GetString()!;

                    txtLog.AppendText($"Autenticación exitosa. Rol: {rol}\r\n");

                    // ── 3. Inicializar SQLite cifrado ─────────────────────
                    txtLog.AppendText("Inicializando base de datos local cifrada...\r\n");
                    string claveHex = DatabaseManager.DerivarClave(password);
                    string connString = DatabaseManager.ObtenerConnectionString(claveHex);
                    DatabaseManager.InicializarBD(connString);
                    txtLog.AppendText("Base de datos local lista.\r\n");

                    // ── 4. Guardar token en sesión estática ───────────────
                    SessionManager.Token = token;
                    SessionManager.UserId = userId;
                    SessionManager.Nombre = nombre;
                    SessionManager.Rol = rol;
                    SessionManager.Email = email;

                    txtLog.AppendText("Sesión iniciada correctamente.\r\n");

                    // ── 5. Abrir módulo de Handheld directamente ──────────
                    this.Hide();
                    using (var handheld = new HandheldForm(email, password))
                    {
                        handheld.ShowDialog();
                    }
                    this.Show();
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                    txtLog.Clear();
                    txtLog.AppendText("Sesión cerrada. Ingrese credenciales de nuevo.\r\n");
                    btnLogin.Enabled = true;
                }
            }
            catch (System.Net.Http.HttpRequestException)
            {
                txtLog.AppendText("No se pudo conectar con el servidor. Ofreciendo modo offline...\r\n");
                var res = MessageBox.Show(
                    "No se pudo conectar con el servidor DIGESETT (Middleware offline).\n\n¿Desea iniciar sesión en Modo Offline para pruebas locales?",
                    "Servidor No Disponible",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (res == DialogResult.Yes)
                {
                    try
                    {
                        string token = "OFFLINE_TEST_TOKEN";
                        string userId = "OFFLINE_USER";
                        string nombre = "Usuario Offline (Pruebas)";
                        string rol = email.Contains("master") ? "CAJERO_MASTER" : (email.Contains("agente") ? "AGENTE_CALLE" : "CAJERO");

                        txtLog.AppendText("Inicializando base de datos local cifrada...\r\n");
                        string claveHex = DatabaseManager.DerivarClave(password);
                        string connString = DatabaseManager.ObtenerConnectionString(claveHex);
                        DatabaseManager.InicializarBD(connString);
                        txtLog.AppendText("Base de datos local lista.\r\n");

                        SessionManager.Token = token;
                        SessionManager.UserId = userId;
                        SessionManager.Nombre = nombre;
                        SessionManager.Rol = rol;
                        SessionManager.Email = email;

                        this.Hide();
                        using (var handheld = new HandheldForm(email, password))
                        {
                            handheld.ShowDialog();
                        }
                        this.Show();
                        txtEmail.Text = "";
                        txtPassword.Text = "";
                        txtLog.Clear();
                        txtLog.AppendText("Sesión cerrada. Ingrese credenciales de nuevo.\r\n");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error en inicialización local: {ex.Message}", "Error Offline", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                btnLogin.Enabled = true;
            }
            catch (Exception ex)
            {
                txtLog.AppendText($"Error inesperado: {ex.Message}\r\n");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLogin.Enabled = true;
            }
        }
    }
}
