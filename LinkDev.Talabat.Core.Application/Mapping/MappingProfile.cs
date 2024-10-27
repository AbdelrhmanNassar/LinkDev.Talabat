
using AutoMapper;
using LinkDev.Talabat.Core._Application.Abstraction.Basket.Mdoels;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Domain.Enities.Basket;
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
            CreateMap<ProductBrand, BrandDto>()
                .ReverseMap();
            CreateMap<ProductCategory, CategoryDto>();

            CreateMap<Product, ProductToReturnDto>()
                .ForMember(Pto => Pto.ProductBrand, O => O.MapFrom(P => P.ProductBrand!.Name))// i should do some configurations because there is properites same name but not same type
				.ForMember(Pto => Pto.ProductCategory, O => O.MapFrom(p => p.ProductCategory!.Name))
                .ForMember(d => d.PictureUrl,O=>O.MapFrom<PictureUrlResolver>())
                .ReverseMap()
                 .ForMember(d => d.ProductBrand, O => O.Ignore()) // Ignore ProductBrand during reverse mapping because this nav property will be always null
            .ForMember(d => d.ProductCategory, O => O.Ignore());
            ;


				
            CreateMap<CustomerBasket, CustomerBusketDto>()
                .ReverseMap();
            CreateMap<BasketItem, BasketItemDto>()
                .ReverseMap();
        }
    }
}
