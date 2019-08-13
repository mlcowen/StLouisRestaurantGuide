using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisRestaurantGuide.Data;
using StLouisRestaurantGuide.Models;
using StLouisRestaurantGuide.ViewModels.Categories;
using StLouisRestaurantGuide.ViewModels.Restaurants;

namespace StLouisRestaurantGuide.Controllers
{
    public class RestaurantController  : Controller
    {
        private ApplicationDbContext context;

        public RestaurantController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //public IActionResult Index()
        //{
        //    //List<Location> locations = context.Locations.ToList();
        //    // where tells the query to get the row that matches the id of the location. This pulls data from the locationReview table 
        //    //List<Location> locations = context.Locations.Include(a => a.LocationReviews).ToList();

        //    List<RestaurantListItemViewModel> restaurants = RestaurantListItemViewModel.GetRestaurants(context);

        //    return View(restaurants);
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    RestaurantCreateViewModel model = new RestaurantCreateViewModel(context);
        //    return View(model);
        //}

    }
}
