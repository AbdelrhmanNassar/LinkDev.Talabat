﻿using LinkDev.Talabat.Apis.Controllers.Controllers.Base;
using LinkDev.Talabat.Apis.Controllers.Controllers.Errors;
using LinkDev.Talabat.Core._Application.Abstraction.Comman;
using LinkDev.Talabat.Core._Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Application.Abstraction.ServiceManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Apis.Controllers.Controllers.Product
{
	[ApiController]
    [Route("api/[controller]")]
    public class ProductController(IServiceManager serviceManager) : ApiControllerBase
	{
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet] //Get:/api/Product
		public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecificationParams specParams) //this is like what we had read in the artical
			//i want the the api  be  at most 2 lines
		 {
			var products = await serviceManager.ProductService.GetAllProductAsync(specParams);
			return Ok(products);
		}

		//[Authorize(AuthenticationSchemes = "Bearer")]
		[HttpGet("{id}")] //Get:/api/Products/id

		public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProduct(int id) //this is like what we had read in the artical
			//i want the the api  be  at most 2 lines
		{
			var product = await serviceManager.ProductService.GetProductAsync(id);

			return Ok(product);
		}

		[HttpGet("brands")] //Get:/api/Products/brands
		public async Task<ActionResult<IReadOnlyList<BrandDto>>> GetBrands()
		{
			var res = await serviceManager.ProductService.GetBrandsAsync();
			//if (res == null)
			//	return NotFound();
			return Ok(res);

		}
		
		[HttpGet("categories")] //Get:/api/Products/categories
		public async Task<ActionResult<IReadOnlyList<CategoryDto>>> GetCategories()
		{
			var res = await serviceManager.ProductService.GetCategoriesAsync();
			//if (res == null)
			//	return NotFound();
			return Ok(res);

		}
	}
}
