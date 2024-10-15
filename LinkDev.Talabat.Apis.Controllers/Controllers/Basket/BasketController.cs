using LinkDev.Talabat.Apis.Controllers.Controllers.Base;
using LinkDev.Talabat.Core._Application.Abstraction.Basket.Mdoels;
using LinkDev.Talabat.Core.Application.Abstraction.ServiceManager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Apis.Controllers.Controllers.Basket
{
	[ApiController]
	public class BasketController(IServiceManager serviceManager) :ApiControllerBase
	{
		[HttpGet]//Get:   api/Basket?id=
		public async Task<ActionResult<CustomerBusketDto>> GetBasket(string id)
		{
			var basket  =await serviceManager.BasketService.GetCustomerBasketAsync(id);
			return Ok(basket);
			 
		}
		[HttpPost]//Get:   api/Basket
		public async Task<ActionResult<CustomerBusketDto>> updateBasket(CustomerBusketDto busketDto)
		{
			var basket  =await serviceManager.BasketService.UpdateCustomerBasketAsync(busketDto);
			return Ok(basket);
			 
		}
		[HttpDelete] //Get:   api/Basket?id=
		public async Task DeleteBasket(string id)
		{
			await serviceManager.BasketService.DeleteCustomerBasketAsync(id);
		}

	}
}
