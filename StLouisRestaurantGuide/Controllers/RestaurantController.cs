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
using StLouisRestaurantGuide.ViewModels.UserVisitLists;
using System.Security.Claims;

namespace StLouisRestaurantGuide.Controllers
{
    public class RestaurantController  : Controller
    {
        private ApplicationDbContext context;

        public RestaurantController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            //List<Restaurant> restaurants = context.Restaurants.ToList();
            // where tells the query to get the row that matches the id of the restaurant. This pulls data from the restaurantReview table 
            //List<Restaurant> restaurants = context.Restaurants.Include(a => a.RestaurantReviews).ToList();

            List<RestaurantListItemViewModel> restaurants = RestaurantListItemViewModel.GetRestaurants(context);

            return View(restaurants);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RestaurantCreateViewModel model = new RestaurantCreateViewModel(context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(RestaurantCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ResetCategoryList(context);
                return View(model);
            }

            model.Persist(context);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int RestaurantId)
        {
            return View(new RestaurantEditViewModel(RestaurantId, context));
        }

        [HttpPost]
        public IActionResult Edit(int RestaurantId, RestaurantEditViewModel restaurant)
        {
            if (!ModelState.IsValid)
            {
                restaurant.ResetCategoryList(context);
                return View(restaurant);
                //return View(new RestaurantEditViewModel());
            }

            restaurant.Persist(RestaurantId, context);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int RestaurantId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(new RestaurantDetailViewModel(RestaurantId, context));
        }


        // used to save to user's list
        [HttpPost]
        public IActionResult Details(int Id, UserVisitListListItemViewModel userVisitList )
        {
            //get current userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            UserVisitList newPlaceToVisit = new UserVisitList
            {
                UserId = userId,
                RestaurantId = Id
            };

            userVisitList.AddItem(newPlaceToVisit, context);
            //save to userViewList database

            return RedirectToAction(actionName: nameof(Index));
        }

    }
}
