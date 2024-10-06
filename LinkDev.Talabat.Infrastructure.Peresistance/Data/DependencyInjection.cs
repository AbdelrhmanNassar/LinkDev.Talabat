
using LinkDev.Talabat.Infrastrucutre.Infrastructure.Date;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance.Data
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistanceServices(this IServiceCollection services ,IConfiguration configuration) {

			services.AddDbContext<StoreContext>(optionsBuilder =>
			{
				optionsBuilder.UseSqlServer(configuration.GetConnectionString("storeConnection"));

			})
				; 
			return services;


		}

	}
}
