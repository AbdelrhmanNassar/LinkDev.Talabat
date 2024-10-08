
using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Mapping
{
	internal class MappingProfile :Profile
	{
        public MappingProfile()
        {
            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductCategory, CategoryDto>();
            CreateMap<Product, ProductToReturnDto>()// i should do some configurations because there is properites same name but not same type
            .ForMember(d => d.ProductBrand, O => O.MapFrom(P => P.ProductBrand.Name))
            .ForMember(d => d.ProductCategory, O => O.MapFrom(P => P.ProductCategory.Name))
            .ForMember(d => d.PictureUrl,O=>O.MapFrom<PictureUrlResolver>());


				;
        }
    }
}
