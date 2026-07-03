namespace Amet.Core.Models
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Rol { get; set; } = string.Empty;

        public string Estado { get; set; } = "ACTIVO";

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}