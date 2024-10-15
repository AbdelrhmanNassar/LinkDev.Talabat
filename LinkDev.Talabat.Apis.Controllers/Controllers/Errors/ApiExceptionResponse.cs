using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Apis.Controllers.Controllers.Errors
{
	public class ApiExceptionResponse : ApiResponse
	{
		

		public ApiExceptionResponse(int statusCode , string? message=null , string? details = null):base(statusCode,message)
        {
			
		
			Details = details;
		}

		public string? Details { get; }

		public override string ToString()
		{
			return JsonSerializer.Serialize(this,new JsonSerializerOptions() {PropertyNamingPolicy =JsonNamingPolicy.CamelCase });
		}
	}
}
