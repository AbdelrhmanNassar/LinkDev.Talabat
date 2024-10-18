using LinkDev.Talabat.Core.Application.Services.Auth;
using LinkDev.Talabat.Core.Domain.Enities.Identity;
using LinkDev.Talabat.Infrastructure.Peresistance.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace LinkDev.Talabat.Api.Extensions
{
	public static class IdentityServices
	{
		public  static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddIdentity<ApplicationUser, IdentityRole>((IdentityOptions) => {
				//IdentityOptions.SignIn.RequireConfirmedAccount = true;
				//IdentityOptions.SignIn.RequireConfirmedEmail = true;
				//IdentityOptions.SignIn.RequireConfirmedPhoneNumber = true;

				//IdentityOptions.Password.RequireNonAlphanumeric = true;//@#$%&
																	   //And More
				IdentityOptions.User.RequireUniqueEmail = true;//Validation
			//	IdentityOptions.User.AllowedUserNameCharacters = "adbqwerty 123"; //allow only this chars to be user name


				IdentityOptions.Lockout.AllowedForNewUsers = true;
				IdentityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(12);
				IdentityOptions.Lockout.MaxFailedAccessAttempts = 5;


			}).AddEntityFrameworkStores<StoreIdentityDbContext>();

			services.Configure<JwtSettings>(configuration.GetSection("JWTSettings"));


			return services;
		}
	}
}
