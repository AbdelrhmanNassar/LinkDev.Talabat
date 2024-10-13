using LinkDev.Talabat.Core.Domain.Enities.Product;
using LinkDev.Talabat.Core.Domain.NewFolder;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Specifications.ProductSpec
{
    public class ProductWithBrandAndCategorySpecifications :BaseSpecifications<Product,int>

    {
        public ProductWithBrandAndCategorySpecifications(string? sort, int? categoryId, int? brandId,int PageSize,int PageIndex) :
                    
            base(p =>
            (!brandId.HasValue || brandId.Value == p.BrandId)
			  &&
            (!categoryId.HasValue || categoryId.Value == p.CategoryId))

        {

			AddIncludes();

            switch (sort) {
                    case "priceAsec":
						AddOrderBy(P=>P.Price);
                        break;

                    case "priceDesc":
						AddOrderByDesc(P => P.Price);
                        break;  
                    case "nameDesc":
						AddOrderByDesc(P => P.Name);
                        break;
                    default:
						AddOrderBy(p => p.Name);
                        break; }
            ///total products 18
            ///pagesize = 5
            ///page index=3 which means i will skip 10 how?
            ///18 /5 =3.6 Take the floor it will be 4 pages each page has 5 but i only have 18 so the forth has only three
            AddPageination(PageSize * (PageIndex -1),PageSize );
        }
         
        public ProductWithBrandAndCategorySpecifications(int id):base(id)
        {
			AddIncludes();
		}


		private protected override void AddIncludes()
		{
			base.AddIncludes();//in case is there is lookup
            Includes.Add(P => P.ProductBrand!);
            Includes.Add(P => P.ProductCategory!);
        }
    }
}
