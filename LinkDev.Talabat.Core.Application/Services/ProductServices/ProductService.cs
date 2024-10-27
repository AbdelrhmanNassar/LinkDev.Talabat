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
        public async Task<BrandDto> GetBrand(int id)
        {
            return  mapper.Map<BrandDto>(await unitOfWork.GetRepository<ProductBrand, int>().GetAsync(id));

        }

        public async Task<IReadOnlyList<CategoryDto>> GetCategoriesAsync()
        {
            return mapper.Map<IReadOnlyList<CategoryDto>>(await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync());
        }

        public async Task<IReadOnlyList<ProductToReturnDto>> GetAllProductAsyncWithNoSpec()
        {
            
            return mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>> (await unitOfWork.GetRepository<Product,int>().GetAllAsync() );
        }

        public async Task<bool> AddProduct(ProductToReturnDto product)
        {
            var mapped = mapper.Map<ProductToReturnDto, Product>(product);
            mapped.CreatedBy = "fd0058b8-2f57-4563-9902-d2b53a6d149b"; // i will keep it there until i make the interceptor to give the the id of admin who edited right now 
            mapped.LastModifiedBy = "fd0058b8-2f57-4563-9902-d2b53a6d149b";
            mapped.NormalizedName = mapped.Name.ToUpper();
            try
            {
                await unitOfWork.GetRepository<Product, int>().AddAsync(mapped);
                var i = await unitOfWork.CompleteAsync();

                return i > 0;
            }
            catch (Exception ex)
            {
                // Log or inspect the exception
                Console.WriteLine($"Error in AddProduct: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateProduct(ProductToReturnDto product)
        {
            var mapped = mapper.Map<ProductToReturnDto, Product>(product);
            mapped.CreatedBy = "fd0058b8-2f57-4563-9902-d2b53a6d149b"; // i will keep it there until i make the interceptor to give the the id of admin who edited right now 
            mapped.LastModifiedBy = "fd0058b8-2f57-4563-9902-d2b53a6d149b";
            mapped.NormalizedName = mapped.Name.ToUpper();
            //
            unitOfWork.GetRepository<Product, int>().UpdateAsync(mapped);
     
            var i = await unitOfWork.CompleteAsync();

            return i > 0 ? true : false;
        ;

        }

        public async Task<bool> DeleteProduct(ProductToReturnDto product)
        {
            var mapped = mapper.Map<ProductToReturnDto, Product>(product);
            var existingBrand = await unitOfWork.GetRepository<Product, int>().GetAsync(product.Id);
            if (existingBrand == null)
            {

                return false;
            }


            unitOfWork.GetRepository<Product, int>().DeleteAsync(existingBrand);
            var result = await unitOfWork.CompleteAsync();

            return result > 0;
        }

        public async Task<bool> AddBrand( BrandDto brandDto)
        {
            var mapped = mapper.Map<BrandDto, ProductBrand>(brandDto);
            mapped.CreatedBy = "fd0058b8-2f57-4563-9902-d2b53a6d149b"; // i will keep it there until i make the interceptor to give the the id of admin who edited right now 
            mapped.LastModifiedBy = "fd0058b8-2f57-4563-9902-d2b53a6d149b";
           
            try
            {
                await unitOfWork.GetRepository<ProductBrand, int>().AddAsync(mapped);
                var i = await unitOfWork.CompleteAsync();

                return i > 0;
            }
            catch (Exception ex)
            {
                // Log or inspect the exception
                return false;
            }
        }

        public async Task<bool> UpdateBrand(BrandDto brandDto)
        {
            var mapped = mapper.Map<BrandDto, ProductBrand>(brandDto);
            mapped.CreatedBy = "fd0058b8-2f57-4563-9902-d2b53a6d149b"; // i will keep it there until i make the interceptor to give the the id of admin who edited right now 
            mapped.LastModifiedBy = "fd0058b8-2f57-4563-9902-d2b53a6d149b";

            try
            {
                 unitOfWork.GetRepository<ProductBrand, int>().UpdateAsync(mapped);
                var i = await unitOfWork.CompleteAsync();

                return i > 0;
            }
            catch (Exception ex)
            {
                //Preferd to be logged
                return false;
            }
        }

        public async Task<bool> DeleteBrand(BrandDto brandDto)
        {
            var mapped = mapper.Map<BrandDto, ProductBrand>(brandDto);
            var existingBrand = await unitOfWork.GetRepository<ProductBrand, int>().GetAsync(brandDto.Id);
            if (existingBrand == null)
            {
               
                return false;
            }

       
            unitOfWork.GetRepository<ProductBrand, int>().DeleteAsync(existingBrand);
            var result = await unitOfWork.CompleteAsync();

            return result > 0;
        }

     
    }
}
