using API.Entities;

namespace API.DTOs;

public class UsuarioShowDto
{
	public int Id { get; set; }
	public string UserName { get; set; }

	

	public DateTime Created { get; set; }
	public DateTime LastLogin { get; set; }

	public string City { get; set; }
	public string Street { get; set; }
	public int HouseNumber { get; set; }
	public string PhoneNumber { get; set; }



	public List<PolizaDto> Polizas { get; set; }
}
