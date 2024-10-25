using LinkDev.Talabat.Core.Domain.Enities.Product;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Talabat.DashBoardAdminstrator.Models
{
    public class ProductViewModel 
    {
            public int Id { get; set; }

            public string Name { get; set; }

            [Required(ErrorMessage = "Description is Required")]
            public string Description { get; set; }

            public IFormFile Image { get; set; }

            public string PictureUrl { get; set; }

            [Required(ErrorMessage = "Price is Required")]
            [Range(1, 100000)]
            public decimal Price { get; set; }

            [Required(ErrorMessage = "ProductBrandId is Required")]
            public int BrandId { get; set; }
            public ProductBrand ProductBrand { get; set; }
        }

    
}
