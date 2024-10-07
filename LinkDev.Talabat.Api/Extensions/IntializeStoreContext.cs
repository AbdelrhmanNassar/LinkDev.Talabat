using LinkDev.Talabat.Core.Domain.Contracts;
using System.Runtime.CompilerServices;

namespace LinkDev.Talabat.Api.Extensions
{
	public static class IntializeStoreContext
	{
		public static async Task<WebApplication>  intializeStoreContex(this WebApplication app)
		{
			#region update Database And ask for object form di container explicilitly
			var scope = app.Services.CreateScope(); //you should dispose the scope after using it
			var services = scope.ServiceProvider;
			var contextInizilaer = services.GetRequiredService<IStoreContextInitialzer>();

			var loggerFactory = services.GetRequiredService<ILoggerFactory>();
			//var logger = services.GetRequiredService<ILogger<Program>>();

			try
			{
				await contextInizilaer.Seed();
				await contextInizilaer.Inialize();

			}
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<Program>();
				logger.LogError("An Error Happened during migration or dataseeding");

			}
			#endregion

			return app;
		}

	}
}
