public class ActaSync
{
    public string id                      { get; set; }
    public string conductorId             { get; set; }
    public int    tipoInfraccionId        { get; set; }
    public string agenteId               { get; set; }
    public string placa                  { get; set; }
    public string estado                 { get; set; } = "PENDIENTE";
    public double montoBase              { get; set; }
    public double montoRecargo           { get; set; } = 0;
    public string fechaHecho             { get; set; }
    public string fechaEmision           { get; set; }
    public string fechaLimitePago        { get; set; }
    public bool   reincidente            { get; set; } = false;
    public string urlEvidencia           { get; set; }
    public bool   identificacionPendiente { get; set; } = false;
    public bool   requiereRetencion       { get; set; } = false;
    public string gruaNumero             { get; set; }
}