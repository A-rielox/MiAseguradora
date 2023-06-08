namespace API.Entities;

public class PolizaCobertura
{
    public int PolizaCoberturaId { get; set; }
    //////////////////////////
    public Cobertura Cobertura { get; set; }
    public int CoberturaId { get; set; }
    //////////////////////////
    public Poliza Poliza { get; set; }
    public int PolizaId { get; set; }
    //////////////////////////
    public int Monto { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;

}
