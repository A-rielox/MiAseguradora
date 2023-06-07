using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
	public static IServiceCollection AddAplicationServices(
						this IServiceCollection services,
						IConfiguration config
					)
	{

		services.AddDbContext<DataContext>(options =>
		{
			options.UseSqlite(config.GetConnectionString("DefaultConnection"));
		});

		services.AddCors();

		services.AddScoped<ITokenService, TokenService>();
		services.AddScoped<IUsuarioRepository, UsuarioRepository>();
		services.AddScoped<ICoberturaRepository, CoberturaRepository>();
		services.AddScoped<IPolizaRepository, PolizaRepository>();
		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		services.AddScoped<LogUserActivity>();
		//services.AddScoped<ILikesRepository, LikesRepository>();
		//services.AddScoped<IMessageRepository, MessageRepository>();

		//services.AddScoped<IUnitOfWork, UnitOfWork>();


		return services;
	}
}
