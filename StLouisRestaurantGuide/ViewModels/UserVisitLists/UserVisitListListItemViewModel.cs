using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StLouisRestaurantGuide.Data;
using StLouisRestaurantGuide.Models;

namespace StLouisRestaurantGuide.ViewModels.UserVisitLists
{
    public class UserVisitListListItemViewModel
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public IdentityUser User { get; set; }
    }
}
