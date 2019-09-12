using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

            return View(context);

        }

        [HttpPost]
        public IActionResult AddToVisitList(int id)
        {
            //get current userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            UserVisitList newPlaceToVisit = new UserVisitList
            {
                UserId = userId,
                RestaurantId = id
            };

            //save to userViewList database
            context.Update(newPlaceToVisit);
            context.SaveChanges();

            return RedirectToPage("./Index");
        }





    }
}
