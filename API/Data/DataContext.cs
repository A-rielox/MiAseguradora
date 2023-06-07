using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<Usuario> Usuarios { get; set; }
	public DbSet<Poliza> Polizas { get; set; }
    public DbSet<Cobertura> Coberturas { get; set; }


    ///////////////////////////////////////////////

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Usuario>()
			.Property(u => u.UserName).IsRequired();
		modelBuilder.Entity<Usuario>()
			.Property(u => u.City).IsRequired();
		modelBuilder.Entity<Usuario>()
			.Property(u => u.PhoneNumber).IsRequired();
		modelBuilder.Entity<Usuario>()
			.Property(u => u.Street).IsRequired();


		modelBuilder.Entity<Poliza>()
			.Property(u => u.PolizaCode).IsRequired();
		modelBuilder.Entity<Poliza>()
			.Property(u => u.Marca).IsRequired();
		modelBuilder.Entity<Poliza>()
			.Property(u => u.Vehiculo).IsRequired();
		modelBuilder.Entity<Poliza>()
			.Property(u => u.Modelo).IsRequired();


		modelBuilder.Entity<Cobertura>()
			.Property(c => c.Descripcion).IsRequired();


		////////////////////////////


		modelBuilder.Entity<Usuario>()
			.HasMany(u => u.Polizas)
			.WithOne(p => p.Usuario)
			.OnDelete(DeleteBehavior.Restrict);

	}
}
