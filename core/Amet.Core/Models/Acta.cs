namespace Amet.Core.Models
{
    public class Acta
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? ConductorId { get; set; }
        public int TipoInfraccionId { get; set; }
        public Guid AgenteId { get; set; }

        public string? Placa { get; set; }

        public string Estado { get; set; } = "EMITIDA";

        public decimal MontoBase { get; set; }
        public decimal MontoRecargo { get; set; } = 0;

        public DateTime FechaHecho { get; set; }
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public DateTime FechaLimitePago { get; set; }

        public bool Reincidente { get; set; } = false;

        public string? UrlEvidencia { get; set; }

        public bool IdentificacionPendiente { get; set; } = false;

        public Conductor? Conductor { get; set; }
        public TipoInfraccion? TipoInfraccion { get; set; }
        public Usuario? Agente { get; set; }
    }
}