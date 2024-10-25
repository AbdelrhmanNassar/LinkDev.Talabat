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
                .ReverseMap();
        }
    }
}
