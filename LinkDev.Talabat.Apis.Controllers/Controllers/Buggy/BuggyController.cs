﻿using LinkDev.Talabat.Apis.Controllers.Controllers.Base;
using LinkDev.Talabat.Apis.Controllers.Controllers.Errors;
using LinkDev.Talabat.Apis.Controllers.Controllers.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
			throw new NotFoundException();//=> 404 
		}
		[HttpGet("badrequest")] // api/Buggy/badreqeust 
		public IActionResult GetBadRequst()
		{
			return BadRequest(new ApiResponse(statusCode: 400)); //=> 400 
		}
		[HttpGet("Unauthrized")] // api/Buggy/Unauthrized 
		public IActionResult GetUnauthrized()
		{
			return Unauthorized(new ApiResponse(statusCode: 401)); //=> 401 
		}
		
		[HttpGet("Forbidden")] // api/Buggy/Forbidden 
		public IActionResult GetForbidden()
		{
			return Forbid(); //=> 500 
		}
		[HttpGet("validationError/{id}")] // api/Buggy/Forbidden 
		public IActionResult GetValidationError(int id)//=> 400
		{
			if (!ModelState.IsValid) {
				var erros = ModelState.Where(m => m.Value.Errors.Count > 0)
									 .ToDictionary(kv => 
									 kv.Key, kv => kv.Value.Errors.Select(e=>e.ErrorMessage).ToList());
	
				return BadRequest(new ValidationApiResponse() { Errors = erros });
			}
				//ModelState.
				//return BadRequest(new ApiResponse(400));
			
					

			return BadRequest();
		}


		//[Authorize]
		//[HttpGet("autherize")]
		//public IActionResult GetAutherize()//=> 400
		//{
		//	return Ok();
		//}



	}
}
