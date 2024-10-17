using LinkDev.Talabat.Apis.Controllers.Controllers.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Apis.Controllers.Controllers
{
	[ApiController]
	[Route("Error/{Code}")]
	[ApiExplorerSettings(IgnoreApi = false)]
	internal class ErrorController :ControllerBase
	{
		[HttpGet]
		public IActionResult Error(int Code)
		{
			if (Code ==(int) HttpStatusCode.NotFound) { 
				var response = new ApiResponse((int)HttpStatusCode.NotFound, $"the requested endpoint{Request.Path} is not found");
			 return NotFound(response);
		}
			return StatusCode(Code,new ApiResponse(Code));

		}
	}
}
