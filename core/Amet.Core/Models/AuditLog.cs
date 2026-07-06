namespace Amet.Core.Models
{
    public class AuditLog
    {
        public long Id { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public string UsuarioId { get; set; } = string.Empty;

        public string Rol { get; set; } = string.Empty;

        public string Accion { get; set; } = string.Empty;

        public string EntidadAfectada { get; set; } = string.Empty;

        public string IdEntidad { get; set; } = string.Empty;

        public Guid? UuidActa { get; set; }

        public string? PayloadAntes { get; set; }

        public string? PayloadDespues { get; set; }

        public string? IpOrigen { get; set; }

        public string Resultado { get; set; } = string.Empty;
    }
}