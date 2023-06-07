using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class PolizaCreateDto
{
	[Required(ErrorMessage = "La marca es requerida.")]
	public string Marca { get; set; }

	[Required(ErrorMessage = "El vehículo es requerido.")]
	public string Vehiculo { get; set; }

	[Required(ErrorMessage = "El modelo es requerido.")]
	public string Modelo { get; set; }
}
