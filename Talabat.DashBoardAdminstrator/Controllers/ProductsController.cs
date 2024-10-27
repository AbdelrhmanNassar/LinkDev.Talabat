using AutoMapper;
using LinkDev.Talabat.Core._Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Application.Abstraction.ServiceManager;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Text.Json;
using Talabat.DashBoardAdminstrator.Helprs;
using Talabat.DashBoardAdminstrator.Models;

namespace Talabat.DashBoardAdminstrator.Controllers
{
    public class ProductsController(IServiceManager serviceManager, IMapper mapper) : Controller
    {
        public async Task< IActionResult> Index()
        {
            var specs = new ProductSpecificationParams();
            var products = await serviceManager.ProductService.GetAllProductAsync(specs);

            var productsViewModel = mapper.Map<IEnumerable< ProductToReturnDto>,IReadOnlyList< ProductViewModel>>(products.Data);
            return View(productsViewModel);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            if ( ModelState.IsValid) {
                if (productViewModel.Image is not null)
                {
                    productViewModel.PictureUrl = PictureSettings.UploadFile(productViewModel.Image, "products");
                    var mapped = mapper.Map<ProductViewModel, ProductToReturnDto>(productViewModel);
                 await   serviceManager.ProductService.AddProduct(mapped);
                  
                }
                else
                {
                    productViewModel.PictureUrl = "images/products/double-caramel-frappuccino.png";
                    var mapped = mapper.Map<ProductViewModel, ProductToReturnDto>(productViewModel);

                 await   serviceManager.ProductService.AddProduct(mapped);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(productViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await serviceManager.ProductService.GetProductAsync(id);
            if (product != null)
            {
                var mapped = mapper.Map<ProductToReturnDto, ProductViewModel>(product);
                //TempData["Brands"] = JsonSerializer.Serialize(mapped.ProductBrand);
                //TempData["Category"] = JsonSerializer.Serialize(mapped.ProductCategory);
                return View(mapped);
            }
            return View();
        }
        [HttpPost]  
        
        public async Task< IActionResult> Edit(int id,ProductViewModel productViewModel)
        {
            if(id != productViewModel.Id)
            {
                return NotFound();
            }
            //the temp data can not deal with complex datatype without serialzing it so you need to serilaze at the view 
            //and deserlize it here
            productViewModel.ProductBrand = JsonSerializer.Deserialize<ProductBrand>(TempData["Brands"]?.ToString()!)!;
            productViewModel.ProductCategory = JsonSerializer.Deserialize<ProductCategory>(TempData["Category"]?.ToString()!)!;

            if ( ModelState.IsValid )

            {
             
                if (productViewModel.Image != null)
                {
                    PictureSettings.DeleteFile(productViewModel.PictureUrl, "products");
                    productViewModel.PictureUrl = PictureSettings.UploadFile(productViewModel.Image, "products");

                }
                else
                    productViewModel.PictureUrl = PictureSettings.UploadFile(productViewModel.Image,"products");
                var mapped = mapper.Map<ProductViewModel, ProductToReturnDto>(productViewModel);//this is the only case i need to do it manunlay because nav properties came with null(keda keda mesh mehtaghom) so i can't map using auto mapper
                //mapped = new ProductToReturnDto()
                //{
                //    Id = id,
                //    Description = productViewModel.Description,
                //    Name = productViewModel.Name,
                //    BrandId = productViewModel.BrandId,
                //    CategoryId = productViewModel.CategoryId,
                //    PictureUrl = productViewModel.PictureUrl,
                //    ProductBrand =productViewModel.ProductBrand.Name ,
                //    Price = productViewModel.Price,
                //    ProductCategory =
                    

                //}
                
               var res = await serviceManager.ProductService.UpdateProduct(mapped);
                if (res == true) 
                    
                  return  RedirectToAction("Index");

            }
            
            return View(productViewModel);
        }

        public async Task<IActionResult> Delete(int id)

        {

            var product = await serviceManager.ProductService.GetProductAsync(id);
            if (product != null)
            {
                var mapped = mapper.Map<ProductToReturnDto, ProductViewModel>(product);
                //TempData["Brands"] = JsonSerializer.Serialize(mapped.ProductBrand);
                //TempData["Category"] = JsonSerializer.Serialize(mapped.ProductCategory);
                return View(mapped);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id,ProductViewModel productViewModel)
        {
            if(id != productViewModel.Id)
                return NotFound();
            try
            {
                var product = await serviceManager.ProductService.GetProductAsync(id);
                if (product.PictureUrl != null)
                {
                    PictureSettings.DeleteFile(productViewModel.PictureUrl, "products");
                }
                await serviceManager.ProductService.DeleteProduct(product);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return View(productViewModel);
            }
           
        }
    }
}
