using LinkDev.Talabat.Core.Domain.Contracts.Persistance.DbInitializers;
using LinkDev.Talabat.Core.Domain.Enities.Identity;
using LinkDev.Talabat.Infrastructure.Peresistance._Common;
using LinkDev.Talabat.Infrastructure.Peresistance.Identity;
using Microsoft.AspNetCore.Identity;

namespace LinkDev.Talabat.Infrastructure.Peresistance._Identity
{
    public sealed class StoreIdentityDbIntailizer(StoreIdentityDbContext context ,UserManager<ApplicationUser> _userManager) : DbContextInitializer (context),	IStoreIdentityInitailzer
	{
		public override async Task SeedAsync()
		{
			if (!_userManager.Users.Any())
			{
				var user = new ApplicationUser()
				{
					DisplayName = "Abdlerhman Ahmed",
					UserName = "Abdelrhman.ahmed",
					Email = "abdoljkhj@gmail.com",

				};
				await _userManager.CreateAsync(user, "abdo1234");
			}
		}
	}
}
