using Azure;
using LinkDev.Talabat.Apis.Controllers.Controllers.Errors;
using LinkDev.Talabat.Core.Application.Abstraction;
using LinkDev.Talabat.Core.Application.Exceptions;
using System.Net;

namespace LinkDev.Talabat.Apis.MiddleWares
{
	//Convention based
	public class ExpceptionHandlerMiddleWare
	{
		private readonly RequestDelegate next;
		private readonly ILogger<ExpceptionHandlerMiddleWare> logger;
		private readonly IWebHostEnvironment webHostEnvironment;

		public ExpceptionHandlerMiddleWare(RequestDelegate next, ILogger<ExpceptionHandlerMiddleWare> logger, IWebHostEnvironment webHostEnvironment)
		{
			this.next = next;
			this.logger = logger;
			this.webHostEnvironment = webHostEnvironment;

		}


		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				//logic Before Next
				await next(httpContext);
				//Logic After Next
				if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
				{
					var response = new ApiResponse((int)HttpStatusCode.NotFound,$"the requested endpoint{httpContext.Request.Path} is not found" );
					httpContext.Response.WriteAsync(response.ToString());
				}

			}
			catch (Exception ex)
			{
				#region logging
				if (webHostEnvironment.IsDevelopment())
				{
					logger.LogError(ex.Message);
				}
				else
				{
					//Production mode
					//log exception in database or File

				} 
				#endregion
				await HandelExceptionsAsyc(httpContext, ex);
			}
		}

		private async Task HandelExceptionsAsyc(HttpContext httpContext, Exception ex)
		{
			ApiResponse response;
			switch (ex)
			{

				case NotFoundException:
			
					httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
					httpContext.Response.ContentType = "application/json";
					response = new ApiResponse(404, ex.Message);
					httpContext.Response?.WriteAsync(response.ToString());


					break;
				case BadRequestException:
					httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
					httpContext.Response.ContentType = "application/json";
					response = new ApiResponse(400, ex.Message);
					httpContext.Response?.WriteAsync(response.ToString());


					break;
				default://Handle system exceptions
					response = webHostEnvironment.IsDevelopment()?
						new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
						:
						response = new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);
					

					httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					httpContext.Response.ContentType = "application/json";

					await httpContext.Response.WriteAsync(response.ToString());


					break;
			}
		}
	}
}
