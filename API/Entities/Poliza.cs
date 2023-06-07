namespace API.Entities;

public class Poliza
{
    public int PolizaId { get; set; }
    public string PolizaCode { get; set; } // el id q va a ver el usuario



    public string Marca { get; set; }
    public string Vehiculo { get; set; }
    public string Modelo { get; set; }




    public Usuario Usuario { get; set; }
    public int UsuarioId { get; set; }
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
