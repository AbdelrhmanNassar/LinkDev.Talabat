using LinkDev.Talabat.Core._Application.Abstraction.Comman;
using LinkDev.Talabat.Core._Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;

namespace LinkDev.Talabat.Core.Application.Abstraction.Product
{
    public interface IProductService
	{
		Task<bool> AddProduct(ProductToReturnDto product);
		Task<bool> UpdateProduct(ProductToReturnDto product);
		Task<bool> DeleteProduct(ProductToReturnDto product);



		Task<bool> AddBrand(BrandDto brandDto);
		Task<bool> UpdateBrand(BrandDto brandDto);
		Task<bool> DeleteBrand(BrandDto brandDto);



		Task<Pagination<ProductToReturnDto>> GetAllProductAsync(ProductSpecificationParams specParams);
		Task<IReadOnlyList<ProductToReturnDto>> GetAllProductAsyncWithNoSpec();

		Task<ProductToReturnDto> GetProductAsync(int id);
		Task<BrandDto> GetBrand(int id);

        Task<IReadOnlyList<BrandDto>> GetBrandsAsync();
		Task<IReadOnlyList<CategoryDto>> GetCategoriesAsync();

	}
}
