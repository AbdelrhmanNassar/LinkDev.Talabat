using LinkDev.Talabat.Core._Application.Abstraction.Comman;
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
		Task<Pagination<ProductToReturnDto>> GetAllProductAsync(ProductSpecificationParams specParams);
		Task<IReadOnlyList<ProductToReturnDto>> GetAllProductAsync();

		Task<ProductToReturnDto> GetProductAsync(int id);

		Task<IReadOnlyList<BrandDto>> GetBrandsAsync();
		Task<IReadOnlyList<CategoryDto>> GetCategoriesAsync();

	}
}
