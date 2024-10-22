using LinkDev.Talabat.Core.Domain.Enities.Identity;
using LinkDev.Talabat.Infrastructure.Peresistance.Identity;
using LinkDev.Talabat.Infrastrucutre.Infrastructure._Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Talabat.DashBoard
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();
			
			#region Identity Configurations
			builder.Services.AddDbContext<StoreIdentityDbContext>(optionsBuilder =>
			{
				optionsBuilder.UseLazyLoadingProxies();
				optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));

			});
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>((IdentityOptions) =>
			{
				//IdentityOptions.SignIn.RequireConfirmedAccount = true;
				//IdentityOptions.SignIn.RequireConfirmedEmail = true;
				//IdentityOptions.SignIn.RequireConfirmedPhoneNumber = true;

				//IdentityOptions.Password.RequireNonAlphanumeric = true;//@#$%&
				//And More
				IdentityOptions.User.RequireUniqueEmail = true;//Validation
															   //	IdentityOptions.User.AllowedUserNameCharacters = "adbqwerty 123"; //allow only this chars to be user 
				IdentityOptions.Lockout.AllowedForNewUsers = true;
				IdentityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(12);
				IdentityOptions.Lockout.MaxFailedAccessAttempts = 5;


			}).AddEntityFrameworkStores<StoreIdentityDbContext>();

			#endregion
			#region StoreConfigurations
			builder.Services.AddDbContext<StoreDbContext>(optionsBuilder =>
			{
				optionsBuilder.UseLazyLoadingProxies();
				optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("storeConnection"));

			});
			#endregion

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}
