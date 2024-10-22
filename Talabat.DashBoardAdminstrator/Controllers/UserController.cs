using LinkDev.Talabat.Core.Domain.Enities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Talabat.DashBoardAdminstrator.Models;

namespace Talabat.DashBoardAdminstrator.Controllers
{
    
    public class UserController(RoleManager<IdentityRole> _roleManager ,UserManager<ApplicationUser> _userManager) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Fetch users asynchronously
            var users = await _userManager.Users
                .Select(user => new UserViewModel
                {
                    DisplayName = user.DisplayName,
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.UserName,
                    PhoneNumber = user.PhoneNumber
                })
                .ToListAsync();

            // Sequentially fetch roles for each user
            foreach (var user in users)
            {
                ApplicationUser u=await _userManager.FindByIdAsync(user.Id);
                if (u != null)
                    user.Roles = await _userManager.GetRolesAsync(u);
            }

            return View(users);
        }
          [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var allRoles = await _roleManager.Roles.ToListAsync();
            var vm = new UserEditViewModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles =  allRoles.Select(
                     r => new EditRoleViewModel()
                    {
                        Name = r.Name,
                        Id = r.Id,
                        IsSelected = _userManager.IsInRoleAsync(user, user.Id).Result
                    }).ToList()
            };
            return View(vm);
        }
        //[HttpPost]
        //public async Task<IActionResult> Edit(string id, UserEditViewModel model)
        //{
        //    ApplicationUser user =await _userManager.FindByIdAsync(id);
        //    var userroles = await _userManager.GetRolesAsync(user);
        //    foreach(var role in model.Roles)
        //    {
        //        if(userroles.Any(r=>r == role.Name) && !role.IsSelected)



        //    }
           
        //    return RedirectToAction(nameof(Index));

        //}


    }
}
