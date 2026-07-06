namespace Amet.Core.Models
{
    public class Canodromo
    {
        public int Id { get; set; }

        public Guid ActaId { get; set; }

        public string Placa { get; set; } = string.Empty;

        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public DateTime? FechaSalida { get; set; }

        public int DiasCobrados { get; set; }

        public decimal CostoTotal { get; set; }

        public string Estado { get; set; } = "RETENIDO";

        public Guid AdminIngresoId { get; set; }
        public Guid? AdminSalidaId { get; set; }

        public Acta? Acta { get; set; }
        public Usuario? AdminIngreso { get; set; }
        public Usuario? AdminSalida { get; set; }
    }
}