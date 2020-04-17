using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GDR.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly UserManager<User> _userManager;
        public UsuariosController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        public IActionResult Index()
        {
            List<User> users = _userManager.Users.ToList();
            return View(users);
        }


    }
}