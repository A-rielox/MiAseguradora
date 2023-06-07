using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CoberturaCreateDto
{
	[Required(ErrorMessage = "La descripción es requerida.")]
	public string Descripcion { get; set; }

	[Required]
	[Range(10, 10000000,
		ErrorMessage = "Valores para {0} deben ser entre {1} y {2}.")]
	public int Monto { get; set; }
}
