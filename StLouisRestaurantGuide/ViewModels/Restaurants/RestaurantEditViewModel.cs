using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisRestaurantGuide.Data;
using StLouisRestaurantGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StLouisRestaurantGuide.ViewModels.Restaurants
{
    public class RestaurantEditViewModel
    {
        public int RestaurantId { get; set; }

        [Required]
        public string Name { get; set; }

        // we need to get a list of the actively checked IDs for each restaurant when we edit.
        // so we declare a list propety up that we can populate later
        public List<CategoryRestaurant> ActiveCategoryIds { get; set; }

        // we also need to get a list of all categories
        // so we declare a list propety up that we can populate later
        public List<Category> Categories { get; set; }

        // we will need this place holder list to push content into after we convert our activecategoryIds list to the right type (int)
        public List<int> CategoryIds { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public string Address { get; set; }

        [Required]
        public string Region { get; set; }

        public RestaurantEditViewModel() { }

        public RestaurantEditViewModel(int RestaurantId, ApplicationDbContext context)
        {
            // populate the form values with data we can easily pull from the database
            Restaurant restaurant = context.Restaurants.Find(RestaurantId);
            this.Name = restaurant.Name;
            this.Description = restaurant.Description;
            this.HoursOfOperation = restaurant.HoursOfOperation;
            this.Address = restaurant.Address;
            this.Region = restaurant.Region;
            this.Categories = context.Categories.ToList();

            // populate our placeholder list of activeCategoryId. we query the categorylocations table for categories that contain this restaurantId
            this.ActiveCategoryIds = context.CategoryRestaurants.Where(a => a.RestaurantId == RestaurantId).ToList();

            // we then need to convert the ActiveCategoryIds to a type of list<int> we do that with this for loop. 
            // note: this is messy and we can probably do this some other way with less code and less converting from one type to another. 
            List<int> CategoriesList = new List<int>();
            foreach (var category in ActiveCategoryIds)
            {
                CategoriesList.Add(category.CategoryId); // push this value into our categorylist list above our foreach loop
            }

            //finally..... we can set the forms CategoryIds element to this CategoriesList as it's now the right type (int)
            this.CategoryIds = CategoriesList;

        }

        public void Persist(int RestaurantId, ApplicationDbContext context)
        {
            Models.Restaurant restaurant = new Models.Restaurant
            {
                Id = RestaurantId,
                Name = this.Name,
                Description = this.Description,
                HoursOfOperation = this.HoursOfOperation,
                Address = this.Address,
                Region = this.Region
            };
            context.Update(restaurant);

            List<CategoryRestaurant> categoryRestaurants = CreateManyToManyRelationships(restaurant.Id);
            restaurant.CategoryRestaurants = categoryRestaurants;
            context.SaveChanges();
        }

        private List<CategoryRestaurant> CreateManyToManyRelationships(int restaurantId)
        {
            return CategoryIds.Select(catId => new CategoryRestaurant { RestaurantId = restaurantId, CategoryId = catId }).ToList();
        }

        internal void ResetCategoryList(ApplicationDbContext context)
        {
            this.Categories = context.Categories.ToList();
        }
    }
}
