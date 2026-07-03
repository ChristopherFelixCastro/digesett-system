namespace Amet.Core.Models
{
    public class Impugnacion
    {
        public int Id { get; set; }

        public Guid ActaId { get; set; }

        public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        public DateTime FechaLimite { get; set; }

        public string Estado { get; set; } = "PENDIENTE";

        public string? TipoResolucion { get; set; }

        public decimal? MontoNuevo { get; set; }

        public Guid? FiscalId { get; set; }

        public DateTime? FechaResolucion { get; set; }

        public string? MotivoCiudadano { get; set; }

        public Acta? Acta { get; set; }

        public Usuario? Fiscal { get; set; }
    }
}