using LinkDev.Talabat.Core.Application.Services.Auth;
using LinkDev.Talabat.Core.Domain.Enities.Identity;
using LinkDev.Talabat.Infrastructure.Peresistance.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LinkDev.Talabat.Api.Extensions
{
    public static class IdentityServices
	{
		public  static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration configuration)
		{
		
		//	services.AddIdentity();
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


			}).	AddEntityFrameworkStores<StoreIdentityDbContext>();

			services.Configure<JwtSettings>(configuration.GetSection("JWTSettings"));
            //	services.AddAuthentication();//CALLED BY DEFUALT WHEN YOU CALL AddIdentity
            //   services.AddAuthentication("Hamada");

            services.AddAuthentication((AuhtenticationOptions) => {
                AuhtenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //"Bearer"
                AuhtenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //"Bearer"
                }
            ).AddJwtBearer((options)=>
                
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    //what should you validate in the token
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew= TimeSpan.Zero,//to make the token expire at time

                    //what is excepted values?
                    // The expected audience value (who the token is meant for, typically your API)
                    ValidAudience = configuration["JWTSettings:Audience"],

                    // The expected issuer value (who issued the token, typically your identity provider)
                    ValidIssuer = configuration["JWTSettings:Issuer"],

                    // The key used to validate the signature of the token (should match what was used to sign it)
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]!)) // Ensure this is the correct key
                }
            );

            //services.AddAuthentication("Bearer");
            //services.AddAuthentication((authenticationOptions) =>
            //{
            //	authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //	authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer((options) =>
            //{
            //	options.TokenValidationParameters = new TokenValidationParameters()
            //	{
            //		ValidateIssuerSigningKey = true,
            //		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"])),
            //		ValidateIssuer = true,
            //		ValidIssuer = configuration["JWTSettings:Issur"],
            //		ValidateAudience = true,
            //		ValidAudience = configuration["JWTSettings:Audience"],
            //		ValidateLifetime = true,
            //		ClockSkew = TimeSpan.Zero
            //	};
            //}

            //);

            return services;
		}
	}
}
