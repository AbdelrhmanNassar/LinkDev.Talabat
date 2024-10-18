using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance._Common
{
	public abstract class DbContextInitializer(DbContext context) : IDbContextIntializer
	{
		public async Task InializeAsync()
		{
			var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
			
			if (pendingMigrations.Any())
				await context.Database.MigrateAsync(); 
		}

		public abstract Task SeedAsync();
	
	}
}
