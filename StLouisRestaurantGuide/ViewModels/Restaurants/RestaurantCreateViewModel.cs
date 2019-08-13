using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using StLouisRestaurantGuide.Data;
using StLouisRestaurantGuide.Models;

namespace StLouisRestaurantGuide.ViewModels.Restaurants
{
    public class RestaurantCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public string Address { get; set; }

        [Display(Name = "Select one or more categories.")]
        public List<int> CategoryIds { get; set; }
        public List<Category> Categories { get; set; }

        [Required]
        public string Region { get; set; }

        public RestaurantCreateViewModel() { }

        public RestaurantCreateViewModel(ApplicationDbContext context)
        {
            //OrderBy(s=>s.name)tells our code to alphabetize results by the name
            this.Categories = context.Categories.OrderBy(s => s.Name).ToList();
        }

        public void Persist(ApplicationDbContext context)
        {
            Models.Restaurant restaurant = new Models.Restaurant
            {
                Name = this.Name,
                Description = this.Description,
                HoursOfOperation = this.HoursOfOperation,
                Address = this.Address,
                Region = this.Region
                //CategoryId = this.CategoryIds,
                //Categories = this.Categories,
            };
            context.Restaurants.Add(restaurant);
            //context.SaveChanges();


            List<CategoryRestaurant> categoryRestaurants = CreateManyToManyRelationships(restaurant.Id);
            restaurant.CategoryRestaurants = categoryRestaurants;
            context.SaveChanges();
        }

        private List<CategoryRestaurant> CreateManyToManyRelationships(int locationId)
        {
            return CategoryIds.Select(catId => new CategoryRestaurant { LocationId = locationId, CategoryId = catId }).ToList();
        }

        internal void ResetCategoryList(ApplicationDbContext context)
        {
            this.Categories = context.Categories.ToList();
        }
    }
}
