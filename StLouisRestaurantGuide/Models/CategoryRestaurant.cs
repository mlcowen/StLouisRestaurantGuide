using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisRestaurantGuide.Models
{
    public class CategoryRestaurant
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int RestaurantId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Restaurant Restaurant { get; set; }

    }
}
