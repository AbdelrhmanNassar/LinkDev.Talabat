using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Application.Abstraction.ServiceManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Talabat.DashBoardAdminstrator.Controllers
{
    public class BrandController(IServiceManager serviceManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var brands = await serviceManager.ProductService.GetBrandsAsync();
            return View(brands);
            
            
        }


   
        public async Task<IActionResult> create(BrandDto brandDto)
            {
            try
            {
             await   serviceManager.ProductService.AddBrand(brandDto);
               return RedirectToAction("Index");
            }
            catch (Exception)
            {

                ModelState.AddModelError("Name","Name is required.");
                return View(brandDto);
            }

         
        } 
        
        public async Task<IActionResult> Delete(int id)
            {
          var brand =await  serviceManager.ProductService.GetBrand(id);
         await   serviceManager.ProductService.DeleteBrand(brand);
            return RedirectToAction("Index");
        
                }

         
        }
        







    }
