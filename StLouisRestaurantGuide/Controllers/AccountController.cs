using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using StLouisRestaurantGuide.ViewModels.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisRestaurantGuide.Controllers
{
    public class AccountController : Controller
    {


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        //[HttpPost]
        //public IActionResult Register(RegisterViewModel model)
        //{
        //    return View();
        //}
    }
}
