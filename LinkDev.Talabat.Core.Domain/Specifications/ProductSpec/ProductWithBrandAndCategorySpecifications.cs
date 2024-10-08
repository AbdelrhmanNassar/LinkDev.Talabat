using LinkDev.Talabat.Core.Domain.Enities.Product;
using LinkDev.Talabat.Core.Domain.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Specifications.ProductSpec
{
    public class ProductWithBrandAndCategorySpecifications :BaseSpecifications<Product,int>

    {
        public ProductWithBrandAndCategorySpecifications():base()
        {
            Includes.Add(P => P.ProductBrand!);
            Includes.Add(P => P.ProductCategory!);
        }   
        public ProductWithBrandAndCategorySpecifications(int id):base(id)
        {
            Includes.Add(P => P.ProductBrand!);
            Includes.Add(P => P.ProductCategory!);
        }
    }
}
