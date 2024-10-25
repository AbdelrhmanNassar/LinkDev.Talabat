using LinkDev.Talabat.Core.Domain.Enities.Identity;
using LinkDev.Talabat.Infrastructure.Peresistance._Common;
using LinkDev.Talabat.Infrastructure.Peresistance._Identity.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System.Reflection;


namespace LinkDev.Talabat.Infrastructure.Peresistance.Identity
{
	public class StoreIdentityDbContext : IdentityDbContext<ApplicationUser,IdentityRole,string>	{

        public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext>  dbContextOptions):
			base(dbContextOptions)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);


			builder.ApplyConfiguration(new AddressConfigurations());
			builder.ApplyConfiguration(new ApplicationUserConfigurations());

			//builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), (type) =>type.Namespace == "LinkDev.Talabat.Infrastructure.Peresistance._Identity.Configurations");
			
			
			
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), (type) => type.GetCustomAttribute<DbContextTypeAttribute>()?.DbContextType == typeof(StoreIdentityDbContext));
			
		}
	}
}
