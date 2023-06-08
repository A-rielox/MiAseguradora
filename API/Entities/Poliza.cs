namespace API.Entities;

public class Poliza
{
    public int PolizaId { get; set; }
    public string PolizaCode { get; set; } // el id q va a ver el usuario


    public string Marca { get; set; }
    public string Vehiculo { get; set; }
    public string Modelo { get; set; }


    public Usuario Usuario { get; set; }
    public int UsuarioId { get; set; }


	//////////////////////////

    public List<PolizaCobertura> CoberturaList { get; set; }
}

