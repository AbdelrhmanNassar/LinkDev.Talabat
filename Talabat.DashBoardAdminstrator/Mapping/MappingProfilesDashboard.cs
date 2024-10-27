using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using Microsoft.AspNetCore.Mvc;
using Talabat.DashBoardAdminstrator.Models;

namespace Talabat.DashBoardAdminstrator.Mapping
{
    public class MappingProfilesDashboard : Profile
    {
        public MappingProfilesDashboard()
        {
            CreateMap<ProductToReturnDto, ProductViewModel>()
     .ForPath(vm => vm.ProductBrand.Name, options => options.MapFrom(dto => dto.ProductBrand))
     .ForPath(vm => vm.ProductCategory.Name, options => options.MapFrom(dto => dto.ProductCategory))
     .ReverseMap()
     .ForMember(dto => dto.ProductBrand, options => options.MapFrom(vm => vm.ProductBrand.Name))
     .ForMember(dto => dto.ProductCategory, options => options.MapFrom(vm => vm.ProductCategory.Name));


      //      CreateMap<ProductViewModel, Product>()
      //.ForMember(p => p.ProductBrand, options => options.MapFrom(vm => vm.ProductBrand))
      //.ForMember(p => p.ProductCategory, options => options.MapFrom(vm => vm.ProductCategory))
      //.ReverseMap();
            }
    }
}
