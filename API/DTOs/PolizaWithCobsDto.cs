namespace API.DTOs;

public class PolizaWithCobsDto
{
	public int PolizaId { get; set; }
	public string PolizaCode { get; set; }
	public string Marca { get; set; }
	public string Vehiculo { get; set; }
	public string Modelo { get; set; }


    public int UsuarioId { get; set; }


    public List<int> CoberturasIdList { get; set; }
}
