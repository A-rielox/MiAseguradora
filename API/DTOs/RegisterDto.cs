using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [Required(ErrorMessage = "El nombre es requerido.")]
    public string UserName { get; set; }
    //[Required] public string City { get; set; }
    //[Required] public string Street { get; set; }
    //[Required] public int HouseNumber { get; set; }

    [Required(ErrorMessage = "La clave es requerida.")]
    [StringLength(20, MinimumLength = 4, ErrorMessage = "La clave debe tener entre 4 a 20 caracteres.")]
    public string Password { get; set; }
}
