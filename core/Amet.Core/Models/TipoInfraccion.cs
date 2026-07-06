namespace Amet.Core.Models
{
    public class TipoInfraccion
    {
        public int Id { get; set; }

        public string Codigo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        public decimal MontoParticular { get; set; }

        public decimal MontoMotocicleta { get; set; }

        public decimal MontoCarga { get; set; }

        public bool RequiereRetencion { get; set; } = false;
    }
}