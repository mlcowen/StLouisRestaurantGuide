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

        [HttpGet]
        public IActionResult Index()
        {
            //get current logged in userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //create a list from uservisitlist db table for the current logged in user
            List<UserVisitList> userList = context.UserVisitLists.Where(a => a.UserId == userId).ToList();

            //create placeholder list to pass data into via forloop
            List<Restaurant> userListRestaurants = new List<Restaurant>();

            foreach (var item in userList)
            {
                //foreach restauraunt ID in the userList - do a db search for that restaurant in the rest. db table. 
                // add the result to the userListRestaurants list and pass that list into the view
                userListRestaurants.Add(context.Restaurants.Where(a => a.Id == item.RestaurantId).Single());
            }

            return View(userListRestaurants);

        }

        //[HttpPost]
        //public IActionResult AddToVisitList(int id)
        //{
        //    //get current userId
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    UserVisitList newPlaceToVisit = new UserVisitList
        //    {
        //        UserId = userId,
        //        RestaurantId = id
        //    };

        //    //save to userViewList database
        //    context.Update(newPlaceToVisit);
        //    context.SaveChanges();

        //    return RedirectToPage("./Index");
        //}

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //get current userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // query uservistlists table for the user id. When found, delete the row with the restaurant id
            var itemToRemove = context.UserVisitLists.Where(a => a.UserId == userId).Single(b => b.RestaurantId == id);

            context.UserVisitLists.Remove(itemToRemove);
  
            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
