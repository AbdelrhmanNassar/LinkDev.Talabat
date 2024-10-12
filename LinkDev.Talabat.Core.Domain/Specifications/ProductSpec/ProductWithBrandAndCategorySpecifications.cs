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
        public ProductWithBrandAndCategorySpecifications(string? sort):base()
        {
            AddOrderBy(p => p.Name);//by defualt will sort by name
            // is sort has one of these value?
            //okay change the sort behavior

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort) {
                    case "priceAsec":
						AddOrderBy(P=>P.Price);
                        break;

                    case "priceDesc":
                        AddOrderBy(null);//why? because i need only one of the (OrderBy - OrderByDesc) has value to decide who i will use
										 //i do this because i add AddOrderBy(p => p.Name); before code and this is could cause
									     //confusion because (OrderBy - OrderByDesc) may have value at same time
						AddOrderByDesc(P => P.Price);
                        break;  
                    case "nameDesc":
                        AddOrderBy(null);//why? because i need only one of the (OrderBy - OrderByDesc) has value to decide who i will use
						AddOrderByDesc(P => P.Name);
                        break;

                }
            }
        }
        public ProductWithBrandAndCategorySpecifications():base()
        {
			Include();
		}   
        public ProductWithBrandAndCategorySpecifications(int id):base(id)
        {
			Include();
		}


		private protected override void Include()
		{
			base.Include();//in case is there is lookup
            Includes.Add(P => P.ProductBrand!);
            Includes.Add(P => P.ProductCategory!);
        }
    }
}
