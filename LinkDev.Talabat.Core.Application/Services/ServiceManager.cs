using AutoMapper;
using LinkDev.Talabat.Core._Application.Abstraction.Auth;
using LinkDev.Talabat.Core._Application.Abstraction.Basket;
using LinkDev.Talabat.Core.Application.Abstraction.Product;
using LinkDev.Talabat.Core.Application.Abstraction.ServiceManager;
using LinkDev.Talabat.Core.Application.Services.Auth;
using LinkDev.Talabat.Core.Application.Services.BasketServices;
using LinkDev.Talabat.Core.Application.Services.ProductServices;
using LinkDev.Talabat.Core.Domain.Contracts.Infrastrcutre;
using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using LinkDev.Talabat.Core.Domain.Enities.Basket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Services
{
	public class ServiceManager : IServiceManager
	{
		private Lazy< IProductService> _productService; //this is the backing field of ProductService
		private Lazy<IBasketService > _basketService; //this is the backing field of ProductService
		private Lazy<IAuthService> _authSerivce;

        [FromServices]
        private IBasketRepository InjectedBasketRepository { get; set; }

        [FromServices]
        private IAuthService InjectedAuthService { get; set; }
        public ServiceManager(IUnitOfWork unitOfWork ,IMapper mapper,IConfiguration configuration)
		{
			_productService = new Lazy<IProductService>(() =>new ProductService(unitOfWork,mapper));
			_basketService = new Lazy<IBasketService>(() =>  //I don't need to make the constructor of service manager depened on IBasketService to create the obj of service manager
			//and i want also to add to maintanine the thread safty so i use this ctor which take func
                new BasketService(this.InjectedBasketRepository, mapper, configuration)
			);
			_authSerivce = new Lazy<IAuthService>(()=> this.InjectedAuthService);
	
		}
		public IProductService ProductService => _productService.Value;

		public IBasketService BasketService => _basketService.Value;

		public IAuthService AuthService => _authSerivce.Value;
	}
}
