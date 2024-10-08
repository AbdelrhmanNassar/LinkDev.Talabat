using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Product;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using LinkDev.Talabat.Core.Domain.NewFolder;
using LinkDev.Talabat.Core.Domain.Specifications.ProductSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Services.ProductServices
{
    internal class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ProductToReturnDto>> GetAllProductAsync()
        {
            var spec = new ProductWithBrandAndCategorySpecifications();
            var products =  mapper.Map<IEnumerable<ProductToReturnDto>>(await unitOfWork.GetRepository<Product, int>().GetAllWithSpecAsync(spec));
            return products;
		}
       



        public async Task<ProductToReturnDto> GetProductAsync(int id)
{

			var spec = new ProductWithBrandAndCategorySpecifications(id);
			var product = mapper.Map<ProductToReturnDto>(await unitOfWork.GetRepository<Product, int>().GetWithSpecAsync(spec));
			return product;
		}

        public async Task<IEnumerable<BrandDto>> GetBrandsAsync()
        {
            return mapper.Map<IEnumerable<BrandDto>>(await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync());

        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            return mapper.Map<IEnumerable<CategoryDto>>(await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync());
        }




    }
}
