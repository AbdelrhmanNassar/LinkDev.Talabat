using LinkDev.Talabat.Core.Application.Abstraction.ServiceManager;
using LinkDev.Talabat.Core.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;


namespace LinkDev.Talabat.Core.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)

		{
			//services.AddAutoMapper(M => M.AddProfile<MappingProfile>());
			//services.AddAutoMapper(typeof(MappingProfile));
			services.AddAutoMapper(typeof(MappingProfile).Assembly);
			services.AddScoped(typeof(IServiceManager), typeof(LinkDev.Talabat.Core.Application.Services.ServiceManager));
			return services;
		}
	}
}
