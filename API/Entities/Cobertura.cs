namespace API.Entities;

public class Cobertura
{
    public int CoberturaId { get; set; }
    public string Descripcion { get; set; }
    public int Monto { get; set; }

    //////////////////////////

    public List<PolizaCobertura> PolizaList { get; set; }

}
 