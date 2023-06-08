using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [Required(ErrorMessage = "El nombre es requerido.")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "La ciudad es requerida.")]
    public string City { get; set; }

    [Required(ErrorMessage = "La calle es requerida.")]
    public string Street { get; set; }

    [Required(ErrorMessage = "El teléfono es requerido.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "El número de casa es requerido.")]
    public int HouseNumber { get; set; }

    [Required(ErrorMessage = "La clave es requerida.")]
    [StringLength(20, MinimumLength = 4, ErrorMessage = "La clave debe tener entre 4 a 20 caracteres.")]
    public string Password { get; set; }
}


//modelBuilder.Entity<Usuario>()
//			.Property(u => u.UserName).IsRequired();
//modelBuilder.Entity<Usuario>()
//			.Property(u => u.City).IsRequired();
//modelBuilder.Entity<Usuario>()
//			.Property(u => u.PhoneNumber).IsRequired();
//modelBuilder.Entity<Usuario>()
//			.Property(u => u.Street).IsRequired();