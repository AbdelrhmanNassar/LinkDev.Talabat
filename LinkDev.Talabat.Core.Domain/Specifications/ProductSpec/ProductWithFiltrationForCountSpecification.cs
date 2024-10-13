using LinkDev.Talabat.Core.Domain.Enities.Product;
using LinkDev.Talabat.Core.Domain.NewFolder;

public class ProductWithFiltrationForCountSpecification : BaseSpecifications<Product, int>
{
	public ProductWithFiltrationForCountSpecification(int? categoryId, int? brandId) :

		base(p =>
		(!brandId.HasValue || brandId.Value == p.BrandId)
		  &&
		(!categoryId.HasValue || categoryId.Value == p.CategoryId))
	{

	}
}
