using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Product;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
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
        => mapper.Map<IEnumerable<ProductToReturnDto>>(await unitOfWork.GetRepository<Product, int>().GetAllAsync());



        public async Task<ProductToReturnDto> GetProductAsync(int id)
        => mapper.Map<ProductToReturnDto>(await unitOfWork.GetRepository<Product, int>().GetAsync(id));

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
