
using LinkDev.Talabat.Api.Extensions;
using LinkDev.Talabat.Api.Services;
using LinkDev.Talabat.Apis.Controllers.Controllers;
using LinkDev.Talabat.Apis.Controllers.Controllers.Errors;
using LinkDev.Talabat.Core.Application;
using LinkDev.Talabat.Core.Application.Abstraction;
using LinkDev.Talabat.Infrastructure.Peresistance;
using LinkDev.Talabat.Infrastrucutre.Infrastructure;
using LinkDev.Talabat.Apis.MiddleWares;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.Api
{
	public class Program
	{
		//[FromServices]
		//public static StoreContext StoreContext { get; set;}
		public static async Task Main(string[] args)
		{
			var webAppilcationBuilder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			//services is the di container
			#region Configure Services
			// Adds services for controllers only to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection  .This method will not
			/// register services used for views or pages.
			webAppilcationBuilder.Services.AddControllers()
				.ConfigureApiBehaviorOptions(options =>
				{
					options.SuppressModelStateInvalidFilter = false;
					options.InvalidModelStateResponseFactory = (ActionContext) =>
					{
						#region You could do this
						//var erros = ActionContext.ModelState.Where(m => m.Value!.Errors.Count > 0)
						//					 .ToDictionary(kv =>
						//					 kv.Key, kv => kv.Value!.Errors.Select(e => e.ErrorMessage).ToList());
						//return new BadRequestObjectResult(new ValidationApiResponse() { Errors = erros }); 
						#endregion

						#region Or this
						var errors = ActionContext.ModelState.Where(e => e.Value!.Errors.Count > 0)
						.Select(e => new ValidationApiResponse.ValidationError()
						{
							Field = e.Key,
							Erros = e.Value!.Errors.Select(e => e.ErrorMessage)
						});
						return new BadRequestObjectResult(new ValidationApiResponse() { Errors = errors });
						#endregion

					};
				})
	.AddApplicationPart(typeof(AssemblyInformation).Assembly);//register required serivce of webapi to di container to work with it 
																			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		//webAppilcationBuilder.Services.Configure<ApiBehaviorOptions>(options =>
		//{
		//	options.InvalidModelStateResponseFactory = (actionContext) =>
		//	{

		//		var errors = actionContext.ModelState.Where(e => e.Value!.Errors.Count > 0)
		//				.Select(e => new ValidationApiResponse.ValidationError()
		//				{
		//					Field = e.Key,
		//					Erros = e.Value!.Errors.Select(e => e.ErrorMessage)
		//				});
		//		return new BadRequestObjectResult(new ValidationApiResponse() { Errors = errors });
		//	};

		//});
			
			
			webAppilcationBuilder.Services.AddInfrastrctureServices(webAppilcationBuilder.Configuration);
			#region Also for configre ApiBehaviorOptions in other way
			//webAppilcationBuilder.Services.Configure<ApiBehaviorOptions>(options => {
			//		options.SuppressModelStateInvalidFilter = true;
			//		options.InvalidModelStateResponseFactory = (ActionContext) =>
			//		{
			//			var erros = ActionContext.ModelState.Where(m => m.Value!.Errors.Count > 0)
			//						 .ToDictionary(kv =>
			//						 kv.Key, kv => kv.Value!.Errors.Select(e => e.ErrorMessage).ToList());
			//			return new BadRequestObjectResult(new ValidationApiResponse() { Errors = erros });

			//		};
			//	}); 
			#endregion
			webAppilcationBuilder.Services.AddEndpointsApiExplorer();
			webAppilcationBuilder.Services.AddSwaggerGen();
			webAppilcationBuilder.Services.AddHttpContextAccessor();


			//webAppilcationBuilder.Services.AddDbContext<StoreContext>(optionsBuilder =>
			//{
			//optionsBuilder.UseSqlServer(webAppilcationBuilder.Configuration.GetConnectionString("storeConnection"));

			//}
			//);
			//	DependencyInjection.AddPersistanceServices(webAppilcationBuilder.Services,webAppilcationBuilder.Configuration);
			webAppilcationBuilder.Services.AddScoped(typeof(ILoggedInUserServices), typeof(LoggedInUserServices));
		///	webAppilcationBuilder.Services.AddScoped(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));
			webAppilcationBuilder.Services.AddPersistanceServices(webAppilcationBuilder.Configuration);
		   webAppilcationBuilder.Services.AddApplicationServices();


			#endregion

			var app = webAppilcationBuilder.Build();//build web application

			#region intialize StoreContext database
			await app.intializeStoreContex();

			#endregion




			// Configure the HTTP request pipeline.
			#region determining MiddleWares before Running = Configure Kestral Middleware 
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
				//internally theses method was need thier method so i register the serivces for them to di container
				app.UseDeveloperExceptionPage();
			}
			app.UseMiddleware<ExpceptionHandlerMiddleWare>();
			app.UseHttpsRedirection();//if you enable https so
									  //any request form http it will redirect to https beacause by defualt request being
									  //http so this will  redirect to https using his security certificate
									  //to increase security

			//			app.UseAuthorization();

			app.UseStatusCodePagesWithRedirects("/Error/{0}");
			app.MapControllers();//to use the route attriute in every controller means  each controller annotated as[ApiController]
								//
		 //app.MapControllerRoute()//for mvc
			app.UseAuthentication();
			app.UseAuthorization();
			#endregion
			app.UseStaticFiles();
			app.Run();
		}
	}
}
