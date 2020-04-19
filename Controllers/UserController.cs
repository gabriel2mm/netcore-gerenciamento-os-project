
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDR.Models;
using GDR.Models.ModelsForViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GDR.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<User> users = _userManager.Users.ToList();
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(User user)
        {

            if (ModelState.IsValid)
            {

                User u = await _userManager.FindByIdAsync(user.Id);
                u.First_Name = user.First_Name;
                u.Last_name = user.Last_name;
                u.Email = user.Email;
                u.Login = user.Login;
                u.UserName = user.Login;

                IdentityResult result = await _userManager.UpdateAsync(u);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(User user)
        {
            User u = await _userManager.FindByIdAsync(user.Id);
            IdentityResult result = await _userManager.DeleteAsync(u);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        [Authorize]
        public IActionResult Reset(string id)
        {
            ResetPassword resetPassword = new ResetPassword()
            {
                Id = id
            };
            return View(resetPassword);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reset(ResetPassword resetPassword)
        {
            if (ModelState.IsValid)
            {
                User u = await _userManager.FindByIdAsync(resetPassword.Id);

                _userManager.PasswordValidators.Clear();
                IdentityResult result = await _userManager.ChangePasswordAsync(u, resetPassword.CurrentPassword, resetPassword.Password);

                if (result.Succeeded)
                {
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", null);
                    }
                    
                }
                else
                {
                    ViewBag.resetError = "Não foi possível trocar a senha, tente novamente!";
                }

            }

            return View(resetPassword);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePerfil(string id)
        {
            User u = await _userManager.FindByIdAsync(id);
            IList<String> roles = await _userManager.GetRolesAsync(u);

            ViewBag.Id = id;
            ViewBag.roles = roles;

            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(string id)
        {
            User u = await _userManager.FindByIdAsync(id);
            List<IdentityRole> roles = _roleManager.Roles.ToList();
            List<IdentityRole> rolesByUser = new List<IdentityRole>();
            foreach (IdentityRole role in roles)
            {
                if (!await _userManager.IsInRoleAsync(u, role.Name))
                {
                    rolesByUser.Add(role);
                }
            }

            ViewBag.Id = id;
            ViewBag.roles = rolesByUser;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(string userId, string role)
        {

            User u = await _userManager.FindByIdAsync(userId);
            IdentityResult result = await _userManager.AddToRoleAsync(u, role);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(UpdatePerfil), new { id = u.Id });
            }
            else
            {
                ViewBag.roleError = "Não foi possível adicionar a role ao perfil";
            }

            return RedirectToAction(nameof(AddRole));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRoleInUser(string userId, string roleName)
        {
            User u = await _userManager.FindByIdAsync(userId);
            IdentityResult result = await _userManager.RemoveFromRoleAsync(u, roleName);

            if (!result.Succeeded)
            {
                ViewBag.errorRole = "Não foi possível remover o perfil do usuário";
            }

            return RedirectToAction(nameof(UpdatePerfil), new { id = userId });
        }
    }
}