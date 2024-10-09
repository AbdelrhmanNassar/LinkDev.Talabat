using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using LinkDev.Talabat.Infrastructure.Peresistance.Interceptors;
using LinkDev.Talabat.Infrastrucutre.Infrastructure.Date;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkDev.Talabat.Infrastructure.Peresistance.UnitOfWork;
using LinkDev.Talabat.Infrastructure.Peresistance.Data;

namespace LinkDev.Talabat.Infrastructure.Peresistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<StoreContext>(optionsBuilder =>
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("storeConnection"));

            });
            services.AddScoped(typeof(IStoreContextInitialzer), typeof(StoreContextInitialzer));
            services.AddScoped(typeof(IStoreContextInitialzer), typeof(StoreContextInitialzer));
            services.AddScoped(typeof(ISaveChangesInterceptor), typeof(CustomSaveChangesInterceptor));//It was before
                                                                                                      //services.AddScoped(typeof(ISaveChangesInterceptor),typeof(SaveChangesInterceptor));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            return services;


        }

    }
}
