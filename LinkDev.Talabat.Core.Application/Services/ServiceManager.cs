using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Product;
using LinkDev.Talabat.Core.Application.Abstraction.ServiceManager;
using LinkDev.Talabat.Core.Application.Services.ProductServices;
using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
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
		public ServiceManager(IUnitOfWork unitOfWork ,IMapper mapper)
		{
			_productService = new Lazy<IProductService>(() =>new ProductService(unitOfWork,mapper));
		}
		public IProductService ProductService => _productService.Value;
	}
}
