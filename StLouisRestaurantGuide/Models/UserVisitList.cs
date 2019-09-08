using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisRestaurantGuide.Models
{
    public class UserVisitList
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public IdentityUser User { get; set; }
    }
}
