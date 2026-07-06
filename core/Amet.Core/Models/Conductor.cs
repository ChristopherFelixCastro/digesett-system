namespace Amet.Core.Models
{
    public class Conductor
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Cedula { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public DateTime? FechaNacimiento { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public bool IdentificacionPendiente { get; set; } = false;
    }
}