namespace Amet.Core.Models
{
    public class Pago
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ActaId { get; set; }

        public string Canal { get; set; } = string.Empty;

        public string NumeroTransaccion { get; set; } = string.Empty;

        public decimal MontoMulta { get; set; }
        public decimal MontoRecargo { get; set; }
        public decimal MontoEstadia { get; set; }
        public decimal MontoTotal { get; set; }

        public DateTime FechaPago { get; set; } = DateTime.Now;

        public Guid? CajeroId { get; set; }

        public Acta? Acta { get; set; }
        public Usuario? Cajero { get; set; }
    }
}