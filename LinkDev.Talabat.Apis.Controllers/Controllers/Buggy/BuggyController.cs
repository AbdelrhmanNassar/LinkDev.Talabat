using LinkDev.Talabat.Apis.Controllers.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Apis.Controllers.Controllers.Buggy
{
	[ApiController]
	public class BuggyController :ApiControllerBase
	{


		[HttpGet("servererror")] // api/Buggy/servererror 
		public IActionResult GetServerError()
		{
			throw new Exception(); //=> 500 
		}
		[HttpGet("NotFound")]
		public IActionResult GetNotFound()// api/Buggy/NotFound 
		{

			return NotFound(); //=> 404 
		}
		[HttpGet("badrequest")] // api/Buggy/badreqeust 
		public IActionResult GetBadRequst()
		{
			return BadRequest(); //=> 400 
		}
		[HttpGet("Unauthrized")] // api/Buggy/Unauthrized 
		public IActionResult GetUnauthrized()
		{
			return Unauthorized(); //=> 401 
		}
		
		[HttpGet("Forbidden")] // api/Buggy/Forbidden 
		public IActionResult GetForbidden()
		{
			return Forbid(); //=> 500 
		}
		[HttpGet("validationError/{id}")] // api/Buggy/Forbidden 
		public IActionResult GetValidationError(int id)//=> 400
		{
			return Ok(); 
		}


		//[Authorize]
		//[HttpGet("autherize")]
		//public IActionResult GetAutherize()//=> 400
		//{
		//	return Ok();
		//}



	}
}
