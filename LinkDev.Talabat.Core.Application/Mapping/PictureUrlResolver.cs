using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace LinkDev.Talabat.Core.Application.Mapping
{
	internal class PictureUrlResolver : IValueResolver<Product, ProductToReturnDto, string?>
	{
        public PictureUrlResolver()
        {
            
        }

        public string? Resolve(Product source, ProductToReturnDto destination, string? destMember, ResolutionContext context)
		{
			if (!string.IsNullOrEmpty(source.PictureUrl))
			{
				//return $"{"https://localhost:7219"}/{source.PictureUrl}"; //i did that becasue i was not use any displayer 
				//but i removed it because i need the url in mvc (dash board)
				return source.PictureUrl ;
			}
			return string.Empty ;
		}
	}
}
