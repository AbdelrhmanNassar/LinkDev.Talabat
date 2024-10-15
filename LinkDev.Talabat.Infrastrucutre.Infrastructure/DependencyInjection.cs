using LinkDev.Talabat.Core.Domain.Contracts.Infrastrcutre;
using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using LinkDev.Talabat.Infrastrucutre.Infrastructure.BasketRepo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastrucutre.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastrctureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IConnectionMultiplexer>(serviceProvider =>
			{
				var connectionString = configuration.GetConnectionString("Redis");
				var connectionMultiplexerObj = ConnectionMultiplexer.Connect(connectionString!);
				return connectionMultiplexerObj;
			});
			services.AddScoped<IBasketRepository, BasketRepositry>();
			return services;


		}
	}
}
