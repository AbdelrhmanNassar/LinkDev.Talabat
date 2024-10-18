using LinkDev.Talabat.Core.Domain.Enities.Identity;
using LinkDev.Talabat.Infrastructure.Peresistance._Identity.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


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
		}
	}
}
