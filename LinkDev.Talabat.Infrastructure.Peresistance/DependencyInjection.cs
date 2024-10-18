using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using LinkDev.Talabat.Infrastructure.Peresistance.Interceptors;
using LinkDev.Talabat.Infrastrucutre.Infrastructure._Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using LinkDev.Talabat.Infrastructure.Peresistance._Date;
using LinkDev.Talabat.Infrastructure.Peresistance.Identity;
using LinkDev.Talabat.Infrastructure.Peresistance._Identity;

namespace LinkDev.Talabat.Infrastructure.Peresistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {


            #region StoreDbContext
            services.AddDbContext<StoreDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("storeConnection"));

            });
            services.AddScoped(typeof(IStoreContextInitialzer), typeof(StoreDbContextInitialzer));
            //services.AddScoped(typeof(IStoreContextInitialzer), typeof(StoreDbContextInitialzer));
            services.AddScoped(typeof(ISaveChangesInterceptor), typeof(CustomSaveChangesInterceptor));//It was before
																									  //services.AddScoped(typeof(ISaveChangesInterceptor),typeof(SaveChangesInterceptor)); 
			#endregion
			#region IdentityDbContext
			services.AddDbContext<StoreIdentityDbContext>(optionsBuilder =>
			{
				optionsBuilder.UseLazyLoadingProxies();
				optionsBuilder.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));

			});
			services.AddScoped(typeof(IStoreIdentityInitailzer), typeof(StoreIdentityDbIntailizer));//use it in the intailzer

			//services.AddScoped(typeof(IStoreContextInitialzer), typeof(StoreDbContextInitialzer));
			//services.AddScoped(typeof(ISaveChangesInterceptor), typeof(CustomSaveChangesInterceptor));//I
			#endregion
			services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            
            return services;


        }

    }
}
