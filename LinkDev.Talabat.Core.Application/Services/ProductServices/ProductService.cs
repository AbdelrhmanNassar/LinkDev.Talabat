using AutoMapper;
using LinkDev.Talabat.Core._Application.Abstraction.Comman;
using LinkDev.Talabat.Core._Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Application.Abstraction.Product;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Application.Exceptions;
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
        public async Task<Pagination<ProductToReturnDto>> GetAllProductAsync(ProductSpecificationParams specParams)
            
        {
            var spec = new ProductWithBrandAndCategorySpecifications(specParams.Sort, specParams.CategoryId, specParams.BrandId, specParams.PageSize, specParams.PageIndex, specParams.Search);
            var products =  mapper.Map<IReadOnlyList<ProductToReturnDto>>(await unitOfWork.GetRepository<Product, int>().GetAllWithSpecAsync(spec));
            var countSpec = new ProductWithFiltrationForCountSpecification(specParams.BrandId,specParams.CategoryId,specParams.Search);

			var count = await unitOfWork.GetRepository<Product,int>().GetCountAsync(countSpec) ;
            return new Pagination<ProductToReturnDto>(specParams.PageIndex, specParams.PageSize,products,count );
		}
   

        public async Task<ProductToReturnDto> GetProductAsync(int id)
            {

			var spec = new ProductWithBrandAndCategorySpecifications(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetWithSpecAsync(spec);
			var productDto = mapper.Map<ProductToReturnDto>(product);
            if (productDto is null)
                throw new NotFoundException(nameof(Product), id);
			return productDto;
		}

        public async Task<IReadOnlyList<BrandDto>> GetBrandsAsync()
        {
            return mapper.Map<IReadOnlyList<BrandDto>>(await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync());

        }

        public async Task<IReadOnlyList<CategoryDto>> GetCategoriesAsync()
        {
            return mapper.Map<IReadOnlyList<CategoryDto>>(await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync());
        }




    }
}
