using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using System.Runtime.CompilerServices;

namespace LinkDev.Talabat.Api.Extensions
{
    public static class IntializeDbContexts
	{
		public static async Task<WebApplication>  intializeStoreDbContex(this WebApplication app)
		{
			#region update Database And ask for object form di container explicilitly
			var scope = app.Services.CreateScope(); //you should dispose the scope after using it
			var services = scope.ServiceProvider;//اللي كنت عملتلها ريجيستر قبل ما تعمل بيلد 
			var StoreContextInizilaer = services.GetRequiredService<IStoreContextInitialzer>();
			
			var loggerFactory = services.GetRequiredService<ILoggerFactory>();
			//var logger = services.GetRequiredService<ILogger<Program>>();

			try
			{
				await StoreContextInizilaer.SeedAsync();
				await StoreContextInizilaer.InializeAsync();
				

			}
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<Program>();
				logger.LogError("An Error Happened during migration or dataseeding");

			}
			#endregion

			return app;
		}
		public static async Task<WebApplication>  intializeStoreIdentityDbContex(this WebApplication app)
		{
			#region update Database And ask for object form di container explicilitly
			var scope = app.Services.CreateScope(); //you should dispose the scope after using it
			var services = scope.ServiceProvider;//اللي كنت عملتلها ريجيستر قبل ما تعمل بيلد 
			var StoreIdentityDbContextInizilaer = services.GetRequiredService<IStoreIdentityInitailzer>();
			
			var loggerFactory = services.GetRequiredService<ILoggerFactory>();
			//var logger = services.GetRequiredService<ILogger<Program>>();

			try
			{
			
				await StoreIdentityDbContextInizilaer.InializeAsync();
				await StoreIdentityDbContextInizilaer.SeedAsync();

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
