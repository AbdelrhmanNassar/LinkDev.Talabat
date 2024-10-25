using AutoMapper;
using LinkDev.Talabat.Core._Application.Abstraction.Auth;
using LinkDev.Talabat.Core._Application.Abstraction.Basket;
using LinkDev.Talabat.Core.Application.Abstraction.ServiceManager;
using LinkDev.Talabat.Core.Application.Mapping;
using LinkDev.Talabat.Core.Application.Services;
using LinkDev.Talabat.Core.Application.Services.Auth;
using LinkDev.Talabat.Core.Application.Services.BasketServices;
using LinkDev.Talabat.Core.Domain.Contracts.Infrastrcutre;
using LinkDev.Talabat.Core.Domain.Enities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


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
	
			services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
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
                #region A Way
                //var userMananger = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                //var SignInManager = serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
                //var jwtSettings = serviceProvider.GetRequiredService<IOptions<JwtSettings>>();
                ////var jwtSettings = services.Configure<JwtSettings>(configuration.GetSection("JWTSettings"));

                //	return () => new AuthService(userMananger, SignInManager,jwtSettings); 
                #endregion
                #region other way (for sure it's better because most of these services which you need are registerd so you don't need to ask twice)
                //(And aslo you registeried auth service(services.AddScoped<IAuthService, AuthService>()) and it will create the dependencties of AuthService because they are
				//registered and it needs it for creating object of AuthService)
              
                return () => serviceProvider.GetRequiredService<IAuthService>(); 
				#endregion
			});

			return services;
		}
	}
}
