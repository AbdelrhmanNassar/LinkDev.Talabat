using LinkDev.Talabat.Apis.Controllers.Controllers.Base;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Application.Abstraction.ServiceManager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Apis.Controllers.Controllers.Product
{
	[ApiController]
	public class ProductController(IServiceManager serviceManager) : ApiControllerBase
	{
		[HttpGet] //Get:/api/Products
		public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts() //this is like what we had read in the artical
			//i want the the api  be  at most 2 lines
		{
			var products = await serviceManager.ProductService.GetAllProductAsync();
			return Ok(products);
		}	
		
		[HttpGet("{id}")] //Get:/api/Products/id
		public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts(int id) //this is like what we had read in the artical
			//i want the the api  be  at most 2 lines
		{
			var product = await serviceManager.ProductService.GetProductAsync(id);
			if (product == null) 
				return NotFound();
			return Ok(product);
		}

		[HttpGet("brands")] //Get:/api/Products/brands
		public async Task<ActionResult< IEnumerable<BrandDto>>> GetBrands()
		{
			var res = await serviceManager.ProductService.GetBrandsAsync();
			if (res == null)
				return NotFound();
			return Ok(res);

		}
		
		[HttpGet("categories")] //Get:/api/Products/categories
		public async Task<ActionResult< IEnumerable<CategoryDto>>> GetCategories()
		{
			var res = await serviceManager.ProductService.GetCategoriesAsync();
			if (res == null)
				return NotFound();
			return Ok(res);

		}
	}
}
