using AutoMapper;
using LinkDev.Talabat.Core._Application.Abstraction.Basket;
using LinkDev.Talabat.Core._Application.Abstraction.Basket.Mdoels;
using LinkDev.Talabat.Core.Application.Abstraction;
using LinkDev.Talabat.Core.Application.Exceptions;
using LinkDev.Talabat.Core.Domain.Contracts.Infrastrcutre;
using LinkDev.Talabat.Core.Domain.Enities.Basket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Services.BasketServices
{
	public class BasketService(IBasketRepository basketRepository, IMapper mapper,IConfiguration configuration) : IBasketService
	{
		public async Task DeleteCustomerBasketAsync(string id)
		{
			var deleted = await basketRepository.DeleteAsync(id);
			if(deleted is false)
				 throw new BadRequestException("unable to delete this");
				
		}

		public async Task<CustomerBusketDto?> GetCustomerBasketAsync(string id)
		{
			var basket = await basketRepository.GetAsync(id);

			if (basket == null)
				throw new NotFoundException(nameof(CustomerBasket),id);
			

			return mapper.Map<CustomerBusketDto?>(basket);

		}

		public async Task<CustomerBusketDto?> UpdateCustomerBasketAsync(CustomerBusketDto basketDto)
		{
			var customerBasket = mapper.Map<CustomerBasket>(basketDto);
			var timeToLive = TimeSpan.FromDays(double.Parse(configuration.GetSection("RedisSetting")["TimeToLiveInDays"]!));
			var updatedBasket = await basketRepository.UpdateAsync(customerBasket, timeToLive);
			if (updatedBasket == null)
				throw new BadRequestException("can't update there is a problem with this basckt");
				return basketDto;
		}
	}
}
