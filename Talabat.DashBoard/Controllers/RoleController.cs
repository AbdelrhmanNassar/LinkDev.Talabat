using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Talabat.DashBoard.Controllers
{
    public class RoleController(RoleManager<IdentityRole> _roleManager) : Controller
    {
        public async Task<IActionResult>()
        {
            //get all the roles
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync(); 
            return View(roles);
        }
    }
}
