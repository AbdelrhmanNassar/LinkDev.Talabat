using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Product.Model;
using LinkDev.Talabat.Core.Application.Abstraction.ServiceManager;
using Microsoft.AspNetCore.Mvc;
using Talabat.DashBoardAdminstrator.Models;

namespace Talabat.DashBoardAdminstrator.Controllers
{
    public class ProductsController(IServiceManager serviceManager, IMapper mapper) : Controller
    {
        public async Task< IActionResult> Index()
        {
            var products = await serviceManager.ProductService.GetAllProductAsync();
            var productsViewModel = mapper.Map  <IReadOnlyList< ProductToReturnDto>,IReadOnlyList< ProductViewModel>>(products);
            return View(productsViewModel);
        }
    }
}
