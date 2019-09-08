using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StLouisRestaurantGuide.Data;
using StLouisRestaurantGuide.Models;
using StLouisRestaurantGuide.ViewModels.Categories;
using StLouisRestaurantGuide.ViewModels.UserVisitLists;

namespace StLouisRestaurantGuide.Controllers
{
    public class UserVisitListController : Controller
    {
        private ApplicationDbContext context;

        public UserVisitListController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {

            return View();

        }




    }
}
