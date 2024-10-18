using AutoMapper;
using LinkDev.Talabat.Core._Application.Abstraction.Auth;
using LinkDev.Talabat.Core._Application.Abstraction.Basket;
using LinkDev.Talabat.Core.Application.Abstraction.ServiceManager;
using LinkDev.Talabat.Core.Application.Mapping;
using LinkDev.Talabat.Core.Application.Services;
using LinkDev.Talabat.Core.Application.Services.Auth;
using LinkDev.Talabat.Core.Application.Services.BasketServices;
using LinkDev.Talabat.Core.Domain.Contracts.Infrastrcutre;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LinkDev.Talabat.Core.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)

		{
			//services.AddAutoMapper(M => M.AddProfile<MappingProfile>());
			//services.AddAutoMapper(M => M.AddProfile(new MappingProfile));
			//services.AddAutoMapper(typeof(MappingProfile));
			//services.AddAutoMapper(typeof(MappingProfile).Assembly);
			services.AddAutoMapper(typeof(MappingProfile));
	
			services.AddScoped(typeof(IServiceManager), typeof(LinkDev.Talabat.Core.Application.Services.ServiceManager));
			services.AddScoped<IBasketService, BasketService>();
			services.AddScoped(typeof(Func<IBasketService>), (servicesProvider) =>
			{
				var mapper = servicesProvider.GetRequiredService<IMapper>();
				var configuration = servicesProvider.GetRequiredService<IConfiguration>();
				var basketRepo = servicesProvider.GetRequiredService<IBasketRepository>();
				return () => new BasketService(basketRepo, mapper, configuration);
			});

			services.AddScoped<IAuthService, AuthService>();

			services.AddScoped(typeof(Func<IAuthService>), (serviceProvider) =>
			{
				return () => serviceProvider.GetRequiredService<IAuthService>();
			});

			return services;
		}
	}
}
