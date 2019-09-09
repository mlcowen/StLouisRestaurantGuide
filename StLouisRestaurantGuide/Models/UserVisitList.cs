using Microsoft.AspNetCore.Identity;
using StLouisRestaurantGuide.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisRestaurantGuide.Models
{
    public class UserVisitList
    {
        public int Id { get; set; }
        public int? Order { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
        // public string ListName { get; set; }
        // public List<Restaurant> Restaurants { get; set; }
        //public IdentityUser User { get; set; }
    }
}
