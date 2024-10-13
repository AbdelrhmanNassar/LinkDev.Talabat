using LinkDev.Talabat.Core.Domain.Enities.Product;
using LinkDev.Talabat.Core.Domain.NewFolder;

public class ProductWithFiltrationForCountSpecification : BaseSpecifications<Product, int>
{
	public ProductWithFiltrationForCountSpecification(int? categoryId, int? brandId,string? search) :

		base(p =>
		(string.IsNullOrEmpty(search) || p.NormalizedName.Contains(search))
			&&
		(!brandId.HasValue || brandId.Value == p.BrandId)
		  &&
		(!categoryId.HasValue || categoryId.Value == p.CategoryId))
	{

	}
}
