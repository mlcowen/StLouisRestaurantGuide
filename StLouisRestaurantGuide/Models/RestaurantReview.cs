using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisRestaurantGuide.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string ReviewHeadline { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
