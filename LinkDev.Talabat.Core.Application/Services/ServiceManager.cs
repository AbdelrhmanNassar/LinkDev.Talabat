using AutoMapper;
using LinkDev.Talabat.Core._Application.Abstraction.Basket;
using LinkDev.Talabat.Core.Application.Abstraction.Product;
using LinkDev.Talabat.Core.Application.Abstraction.ServiceManager;
using LinkDev.Talabat.Core.Application.Services.BasketServices;
using LinkDev.Talabat.Core.Application.Services.ProductServices;
using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Services
{
	internal class ServiceManager : IServiceManager
	{
		private Lazy< IProductService> _productService; //this is the backing field of ProductService
		private Lazy<IBasketService > _basketService; //this is the backing field of ProductService
		public ServiceManager(IUnitOfWork unitOfWork ,IMapper mapper,IConfiguration configuration,Func<IBasketService> basketServiceFactory)
		{
			_productService = new Lazy<IProductService>(() =>new ProductService(unitOfWork,mapper));
			_basketService = new Lazy<IBasketService>(basketServiceFactory);
		}
		public IProductService ProductService => _productService.Value;

		public IBasketService BasketService => _basketService.Value;
	}
}
