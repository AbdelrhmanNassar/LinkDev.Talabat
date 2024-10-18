using LinkDev.Talabat.Core.Application.Services.Auth;
using LinkDev.Talabat.Core.Domain.Enities.Identity;
using LinkDev.Talabat.Infrastructure.Peresistance.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;

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

			//services.AddAuthentication("Bearer");
			services.AddAuthentication((authenticationOptions) =>
			{
				authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer((options)=>
			{
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"])),
					ValidateIssuer = true,
					ValidIssuer = configuration["JWTSettings:Issur"],
					ValidateAudience = true,
					ValidAudience = configuration["JWTSettings:Audience"],
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero

				};
			}
			
			);

			return services;
		}
	}
}
