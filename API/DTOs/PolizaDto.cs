using API.Entities;

namespace API.DTOs;

public class PolizaDto
{
	public int PolizaId { get; set; }
	public string PolizaCode { get; set; } // el id q va a ver el usuario


	public string Marca { get; set; }
	public string Vehiculo { get; set; }
	public string Modelo { get; set; }


	public int UsuarioId { get; set; }
}