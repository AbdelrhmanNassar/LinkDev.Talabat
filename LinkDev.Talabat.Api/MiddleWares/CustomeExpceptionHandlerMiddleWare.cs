using LinkDev.Talabat.Apis.Controllers.Controllers.Errors;
using LinkDev.Talabat.Core.Application.Abstraction;
using System.Net;

namespace LinkDev.Talabat.Apis.MiddleWares
{
	internal class CustomeExpceptionHandlerMiddleWare
	{
		private readonly RequestDelegate next;
		private readonly ILogger<CustomeExpceptionHandlerMiddleWare> logger;
		private readonly IWebHostEnvironment webHostEnvironment;

		public CustomeExpceptionHandlerMiddleWare(RequestDelegate next, ILogger<CustomeExpceptionHandlerMiddleWare> logger, IWebHostEnvironment webHostEnvironment)
		{
			this.next = next;
			this.logger = logger;
			this.webHostEnvironment = webHostEnvironment;

		}


		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await next(httpContext);
				if(httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
				{
					var response = new ApiResponse((int)HttpStatusCode.NotFound,$"the requested endpoint{httpContext.Request.Path} is not found" );
					httpContext.Response.WriteAsync(response.ToString());
				}
			}
			catch (Exception ex)
			{
				ApiResponse response;
				switch (ex) {

					case NotFoundException:
						httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
						httpContext.Response.ContentType = "application/json";
						 response = new ApiResponse(404,ex.Message);
						httpContext.Response.WriteAsync(response.ToString());


						break;
				default:
					
						//Development mode
						if (webHostEnvironment.IsDevelopment())
						{
							logger.LogError(ex.Message);

							response = new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace);
						}
						else
						{
							//Production mode
							response = new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);
						}
						httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
						httpContext.Response.ContentType = "application/json";

						await httpContext.Response.WriteAsync(response.ToString());


						break;
				}
			}
		}
	}
}
