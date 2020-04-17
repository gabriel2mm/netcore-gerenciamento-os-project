using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDR.Models;
using GDR.Models.ModelsForViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GDR.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<IdentityRole> roles = _roleManager.Roles.ToList();
            ViewBag.roles = roles;


            var user = await _userManager.FindByNameAsync("gabriel2mm");
            await _userManager.AddToRoleAsync(user, "Admin");
            

            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Roles(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = model.Name
                };

                var result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Roles");
                }
            }

            return View("Roles", model);
        }


        public async Task<IActionResult> update(String id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            return View("update", role);
        }

        [HttpPost]
        public async Task<IActionResult> update(IdentityRole model)
        {

            IdentityRole role = await _roleManager.FindByIdAsync(model.Id);
            role.Name = model.Name;
            IdentityResult result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}