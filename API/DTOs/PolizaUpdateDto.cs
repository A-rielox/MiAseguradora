using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class PolizaUpdateDto
{
	[Required(ErrorMessage = "La PolizaId es requerida.")]
	public int PolizaId { get; set; }


	// public string PolizaCode { get; set; } // el id q va a ver el usuario

	[Required(ErrorMessage = "La marca es requerida.")]
	public string Marca { get; set; }

	[Required(ErrorMessage = "El vehículo es requerido.")]
	public string Vehiculo { get; set; }

	[Required(ErrorMessage = "El modelo es requerido.")]
	public string Modelo { get; set; }


	// public int UsuarioId { get; set; } lo agarro del token
}
