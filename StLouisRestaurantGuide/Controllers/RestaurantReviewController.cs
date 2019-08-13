using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisRestaurantGuide.Data;
using Microsoft.AspNetCore.Mvc;
using StLouisRestaurantGuide.Models;
using StLouisRestaurantGuide.ViewModels.RestaurantReviews;

namespace StLouisRestaurantGuide.Controllers
{
    public class RestaurantReviewController : Controller
    {
        private ApplicationDbContext context;

        public RestaurantReviewController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<RestaurantReview> restaurantReviews = context.RestaurantReviews.ToList();
            return View(restaurantReviews);
        }

        [HttpGet]
        public IActionResult Create(int RestaurantId)
        {
            Restaurant restaurantResult = context.Restaurants.Where(a => a.Id == RestaurantId).Single();
            ViewBag.restaurantName = restaurantResult.Name;

            return View();
        }

        [HttpPost]
        public IActionResult Create(int RestaurantId, RestaurantReviewCreateViewModel model)
        {

            model.Persist(context);
            return RedirectToAction(controllerName: "Restaurant", actionName: "Index");
        }
    }
}
