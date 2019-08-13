using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisRestaurantGuide.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public List<RestaurantReview> RestaurantReviews { get; set; }
        //public Category Category { get; set; }
        public IList<CategoryRestaurant> CategoryRestaurants { get; set; }
    }
}
