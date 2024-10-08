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
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;
		private readonly Lazy<IProductService> _productService;
		public IProductService ProductService => _productService.Value ;

        public ServiceManager(IUnitOfWork unitOfWork,IMapper mapper )
        {
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
			_productService = new Lazy<IProductService>(()=>new ProductService(unitOfWork,mapper));
		}


    }
}
