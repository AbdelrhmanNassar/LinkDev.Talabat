using LinkDev.Talabat.Core._Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Abstraction.Product
{
	public interface IProductService
	{
		Task<IReadOnlyList<ProductToReturnDto>> GetAllProductAsync(ProductSpecificationParams specParams);

		Task<ProductToReturnDto> GetProductAsync(int id);

		Task<IReadOnlyList<BrandDto>> GetBrandsAsync();
		Task<IReadOnlyList<CategoryDto>> GetCategoriesAsync();

	}
}
