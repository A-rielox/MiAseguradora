using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class PoCoCreateDto
{
	// p' poli
	[Required(ErrorMessage = "La marca es requerida.")]
	public string Marca { get; set; }

	[Required(ErrorMessage = "El vehículo es requerido.")]
	public string Vehiculo { get; set; }

	[Required(ErrorMessage = "El modelo es requerido.")]
	public string Modelo { get; set; }

	// p' cobs
	public List<int> CoberturasIdsList { get; set; } = new List<int> { };
}
