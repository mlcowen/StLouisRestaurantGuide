using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StLouisRestaurantGuide.Data;
using StLouisRestaurantGuide.Models;

namespace StLouisRestaurantGuide.ViewModels.Restaurants
{
    public class RestaurantListItemViewModel
    {
        // Declare properties of the LocationListItemViewModel, just like we do in a class
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public string Address { get; set; }
        public List<RestaurantReview> RestaurantReviews { get; set; }
        public double AverageRating { get; set; }


        //method to get locations. This is called in the controller to pass the data to the view
        public static List<RestaurantListItemViewModel> GetRestaurants(ApplicationDbContext context)
        {
            // first we have to query the db to get a list of restaurants. we save this to a list
            // the .Include() method ensures it pulls the associated reviews from the restaurantReviews table
            IList<Restaurant> restaurants = context.Restaurants.Include(a => a.RestaurantReviews).ToList();


            //declare a new list. This will be used in our foreach loop to hold each individual instance of a restaurant 
            //we add data to this list at the end of our foreach loop 
            List<RestaurantListItemViewModel> viewDataList = new List<RestaurantListItemViewModel>();

            // we need to iterate over the list we queried from the DB. Then print each row (restaurant) to the view
            foreach (Restaurant restaurant in restaurants)
            {
                //every time we loop through we create a new instance of the restaurantListItemViewModel. 
                //look up recursion to get an explanation of how this works
                RestaurantListItemViewModel thisSpecificLocation = new RestaurantListItemViewModel();

                thisSpecificLocation.Id = restaurant.Id;
                thisSpecificLocation.Name = restaurant.Name;
                thisSpecificLocation.Description = restaurant.Description;
                thisSpecificLocation.HoursOfOperation = restaurant.HoursOfOperation;
                thisSpecificLocation.Address = restaurant.Address;
                thisSpecificLocation.RestaurantReviews = restaurant.RestaurantReviews;

                if (restaurant.RestaurantReviews.Count > 0)
                {
                    //if we have reviews we want to calculate the average rating
                    thisSpecificLocation.AverageRating = Math.Round(restaurant.RestaurantReviews.Average(x => x.Rating), 2);
                }
                else
                {
                    //if there are no ratings, just set the average rating to 0. The else statement in the view will prevent 0 from showing.
                    thisSpecificLocation.AverageRating = 0;
                }

                //push our new instance of the class into our placeholder (viewData) list
                viewDataList.Add(thisSpecificLocation);
            }
            return viewDataList;
        }
    }
}
