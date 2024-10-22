using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using Talabat.DashBoardAdminstrator.Models;

namespace Talabat.DashBoardAdminstrator.Controllers
{
    public class RoleController(RoleManager<IdentityRole> _roleManager) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //get all the roles
            var roles = await _roleManager.Roles.ToListAsync(); 
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                //get all the roles
                var roles = await _roleManager.RoleExistsAsync(roleViewModel.Name);//search by name also
                if (!roles)
                {
                    var identityRole=new IdentityRole(roleViewModel.Name);
                   await _roleManager.CreateAsync(identityRole);
                }
                else
                {
                    ModelState.AddModelError(string.Empty,"Role is exisit");
                }
             
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Name must be less then that !");
            }
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
          
                //get all the roles
                var role = await _roleManager.FindByIdAsync(id);//search by name also
                var res = await _roleManager.DeleteAsync(role!);
            if (!res.Succeeded)
                ModelState.AddModelError(string.Empty, "Can not Delete this role");
          
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var mappedRole = new EditRoleViewModel()//she didn't use is selected
            {
                Id = id,
                Name = role!.Name!
            };

          
              return View(mappedRole);
        } 
        [HttpPost]
        public async Task<IActionResult> Edit(string id,EditRoleViewModel editRoleViewModel)
        {
           
            if (ModelState.IsValid)
            {
                //get all the roles
                var role = await _roleManager.FindByIdAsync(id);//search by name also
                if (role is not null)
                {
                    role.Name=editRoleViewModel.Name;   
                    await _roleManager.UpdateAsync(role);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Role is not exisit");
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Name must be less then that !");
            }
            return RedirectToAction(nameof(Index));

        }


    }
}
