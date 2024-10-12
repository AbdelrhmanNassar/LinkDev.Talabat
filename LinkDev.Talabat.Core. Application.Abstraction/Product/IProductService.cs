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
		Task<IReadOnlyList<ProductToReturnDto>> GetAllProductAsync(string? sort);

		Task<ProductToReturnDto> GetProductAsync(int id);

		Task<IReadOnlyList<BrandDto>> GetBrandsAsync();
		Task<IReadOnlyList<CategoryDto>> GetCategoriesAsync();

	}
}
