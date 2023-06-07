using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Helpers;

public class LogUserActivity : IAsyncActionFilter
{
	public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
	{
		// voy a ejecutar ___ despues de q el user haya hecho lo suyo ( cuando la accion en la api se halla completado )
		var resultContext = await next();

		// es true si el token q manda se pudo autenticar
		if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

		var userName = resultContext.HttpContext.User.GetUsername();
		var repo = resultContext.HttpContext.RequestServices.GetRequiredService<IUsuarioRepository>();
		var user = await repo.GetUserByUsernameAsync(userName);

		user.LastLogin = DateTime.Now;
		await repo.SaveAllAsync();
	}
}
