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




        //public async Task<IActionResult> AddToVisitList(int id)
        //{
        //    //get current userId
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    UserVisitList newPlaceToVisit = new UserVisitList();
        //    newPlaceToVisit.UserId = userId;
        //    newPlaceToVisit.RestaurantId = id;

        //    //save to userViewList database
        //    context.UserVisitLists.Add(newPlaceToVisit);
        //    await context.SaveChangesAsync();

        //    return RedirectToPage("./UserVistList/Index");
        //}

        [HttpGet]
        public IActionResult Details(int RestaurantId)
        {


   

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var User = await context.Users.SingleOrDefaultAsync(m => m.Id == Id_of_AspNetUser);
            //if (User == null)
            //{
            //    return NotFound();
            //}

            // context is the variable name for ApplicationDbContext. Restaurants is the table in the database
            // where tells the query to get the row that matches the id of the restaurant. This line grabs the restaurant detail information
            // .include tells the query to grab the related reviews for this restaurant from the restaurantReviews table. This line grabs each review for a restaurant 
            //IList<Restaurant> restaurants = context.Restaurants.Where(a => a.Id == id).Include(a => a.RestaurantReviews).ToList();

            // populate our placeholder list of activeCategoryId. we query the categoryrestaurants table for categories that contain this restaurantId
            //List<CategoryRestaurant> activeCategoryIds = context.CategoryRestaurants.Where(a => a.RestaurantId == id).ToList();

            //IList<string> activeCategoryNames = new List<string>();


            //foreach (var item in activeCategoryIds)
            //{
            //    string category = context.Categories.Where(a => a.Id == item.CategoryId).Select(a=> a.Name).ToString();
            //    activeCategoryNames.Add( category );

            //}
            //ViewBag.activeCategoryNames = activeCategoryNames;

            // return View(locations);
            return View(new RestaurantDetailViewModel(RestaurantId, context));
        }

    }
}
