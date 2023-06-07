using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CoberturaUpdateDto
{
	[Required(ErrorMessage = "La Id es requerida.")]
	public int CoberturaId { get; set; }

	[Required(ErrorMessage = "La descripción es requerida.")]
	public string Descripcion { get; set; }

	[Required]
	[Range(10, 10000000,
		ErrorMessage = "Valores para {0} deben ser entre {1} y {2}.")]
	public int Monto { get; set; }
}
