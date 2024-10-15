using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Apis.Controllers.Controllers.Errors
{
	internal class ApiResponse
	{
		public int StautsCode { get; set; }
		public string? Messages { get; set; }


		public ApiResponse(int statusCode, string? message = null) {

			StautsCode = statusCode;
			Messages = message ?? GetDefaultMessageForStautsCode(statusCode);

		}

		private string? GetDefaultMessageForStautsCode(int statusCode) {
			return statusCode switch
			{
				400 => "A bad request, you have made",
				401 => "Authorized, you are not",
				404 => "Resource was not found",
				500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate",
				_ => null
			};
				}
	}
}
