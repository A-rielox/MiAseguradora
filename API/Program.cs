using API.Data;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();








builder.Services.AddAplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);












var app = builder.Build();
// para ocupar mi middleware de excepciones y no tener que poner try-catch por todos lados
app.UseMiddleware<ExceptionMiddleware>();








if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();








// debe ir entre UseRouting y Endpoint, y antes de Authorization y UseAuthentication
app.UseCors(builder => builder.AllowAnyHeader()
		.AllowAnyMethod().AllowAnyOrigin());




app.UseAuthentication();
app.UseAuthorization();







app.MapControllers();






// para el seeding de users, va despues de MapControllers y antes de .Run
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
// try-catch p' errores durante el seeding
try
{
	var context = services.GetRequiredService<DataContext>();
	//var userManager = services.GetRequiredService<UserManager<AppUser>>();
	//var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

	await context.Database.MigrateAsync();
	await Seed.SeedUsuarios(context);
	//await Seed.SeedUsers(userManager, roleManager);

	await Seed.SeedPolizas(context);
	await Seed.SeedCoberturas(context);
}
catch (Exception ex)
{
	var logger = services.GetService<ILogger<Program>>();
	logger.LogError(ex, "An error occurred during migration");
}







app.Run();
