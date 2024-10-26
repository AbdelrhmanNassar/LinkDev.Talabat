using LinkDev.Talabat.Core._Application.Abstraction.Auth.Models;
using LinkDev.Talabat.Core.Domain.Enities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Talabat.DashBoardAdminstrator.Controllers
{
    public class AdminController(UserManager<ApplicationUser> _userManager ,
        SignInManager<ApplicationUser> _signInManager,
        RoleManager<IdentityRole> _roleManager
        ) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        } 

        [HttpPost]
        public  async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("error", "Invalid Login");
             return    RedirectToAction(nameof(Login));
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user,model.Password,false);
            if (result.Succeeded && await _userManager.IsInRoleAsync(user,"Admin"))
            {
                return RedirectToAction(nameof(Index), "Home");
           
            }
            ModelState.AddModelError("error", "Invalid Login");
            return RedirectToAction(nameof(Login));


        }

        public  IActionResult Logout()
        {
            return RedirectToAction(nameof(Login));
        }

    }
}
