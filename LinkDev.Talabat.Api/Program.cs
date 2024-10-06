
using LinkDev.Talabat.Infrastructure.Peresistance.Data;
using LinkDev.Talabat.Infrastrucutre.Infrastructure.Date;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace LinkDev.Talabat.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var webAppilcationBuilder = WebApplication.CreateBuilder(args);
			
			// Add services to the container.
			//services is the di container
			#region Configure Services
			// Adds services for controllers only to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection  .This method will not
			/// register services used for views or pages.
			webAppilcationBuilder.Services.AddControllers();//register required serivce of webapi to di container to work with it 
														// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			webAppilcationBuilder.Services.AddEndpointsApiExplorer();
			webAppilcationBuilder.Services.AddSwaggerGen();
			//webAppilcationBuilder.Services.AddDbContext<StoreContext>(optionsBuilder =>
			//{
			//optionsBuilder.UseSqlServer(webAppilcationBuilder.Configuration.GetConnectionString("storeConnection"));

			//}
			//);
			//	DependencyInjection.AddPersistanceServices(webAppilcationBuilder.Services,webAppilcationBuilder.Configuration);
			webAppilcationBuilder.Services.AddPersistanceServices(webAppilcationBuilder.Configuration);
			#endregion

			var app = webAppilcationBuilder.Build();//build web application

			// Configure the HTTP request pipeline.
			#region determining MiddleWares before Running = Configure Kestral Middleware 
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
				//internally theses method was need thier method so i register the serivces for them to di container
			}

			app.UseHttpsRedirection();//if you enable https so
									  //any request form http it will redirect to https beacause by defualt request being
									  //http so this will  redirect to https using his security certificate
									  //to increase security

			//			app.UseAuthorization();


			app.MapControllers();//to use the route attriute in every controller
			#endregion

			app.Run();
		}
	}
}
