using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace API.Data;

public class Seed
{
	public static async Task SeedUsuarios(DataContext context)
	{
		if (await context.Usuarios.AnyAsync()) return;

		var userData = await File.ReadAllTextAsync("Data/UsuarioSeedData.json");

		// var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

		// var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
		var users = JsonConvert.DeserializeObject<List<Usuario>>(userData);// The solution was to change from System.Text.Json to Newtonsoft Json with this line

		foreach (var user in users)
		{
			using var hmac = new HMACSHA512();

			user.UserName = user.UserName.ToLower();
			user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("P@ssword1"));
			user.PasswordSalt = hmac.Key;

			context.Usuarios.Add(user);
		}

		await context.SaveChangesAsync();
	}

	public static async Task SeedPolizas(DataContext context)
	{
		if (await context.Polizas.AnyAsync()) return;

		var polizaData = await File.ReadAllTextAsync("Data/PolizaSeedData.json");

		// var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

		var polizas = JsonConvert.DeserializeObject<List<Poliza>>(polizaData);// The solution was to change from System.Text.Json to Newtonsoft Json with this line


		foreach (var poliza in polizas)
		{
			context.Polizas.Add(poliza);
		}

		await context.SaveChangesAsync();
	}

	public static async Task SeedCoberturas(DataContext context)
	{
		if (await context.Coberturas.AnyAsync()) return;

		var coberturaData = await File.ReadAllTextAsync("Data/CoberturaSeedData.json");

		// var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

		var coberturas = JsonConvert.DeserializeObject<List<Cobertura>>(coberturaData);// The solution was to change from System.Text.Json to Newtonsoft Json with this line


		foreach (var cobertura in coberturas)
		{
			context.Coberturas.Add(cobertura);
		}

		await context.SaveChangesAsync();
	}

	public static async Task SeedPoCo(DataContext context)
	{
		if (await context.PolizaCoberturas.AnyAsync()) return;

		var pocoData = await File.ReadAllTextAsync("Data/PoCoSeedData.json");

		// var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

		var pocos = JsonConvert.DeserializeObject<List<PolizaCobertura>>(pocoData);// The solution was to change from System.Text.Json to Newtonsoft Json with this line


		foreach (var poco in pocos)
		{
			context.PolizaCoberturas.Add(poco);
		}

		await context.SaveChangesAsync();
	}


}
