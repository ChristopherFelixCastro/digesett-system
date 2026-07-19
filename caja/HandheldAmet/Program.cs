using System;
using System.Windows.Forms;

namespace CajaAmet
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                SQLitePCL.Batteries_V2.Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al inicializar el motor de base de datos local:\n\n{ex.Message}\n\n" +
                    "La aplicación se cerrará.",
                    "Error Crítico - SQLCipher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
