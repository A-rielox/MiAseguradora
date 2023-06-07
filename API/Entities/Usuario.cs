using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class Usuario
{
	public int Id { get; set; }
	public string UserName { get; set; }

	public byte[] PasswordHash { get; set; }
	public byte[] PasswordSalt { get; set; }


    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime LastLogin { get; set; } = DateTime.Now;

    public string City { get; set; }
	public string Street { get; set; }
    public int HouseNumber { get; set; }
	public string PhoneNumber { get; set; }



    // public List<Photo> Photos { get; set; } = new ();

    public List<Poliza> Polizas { get; set; }
}


/*

[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public string Url { get; set; }
    public bool IsMain { get; set; }
    public string PublicId { get; set; }

    // p'q ocupe la id del AppUser como foreign-key, y paq la prop AppUserId NO sea nullable ( NO puede
    // haber fotos q no esten relacionadas a un AppUser )
    public AppUser AppUser { get; set; }
    public int AppUserId { get; set; }
}

*/
