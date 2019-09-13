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
        public string ListName { get; set; }
        public List<Restaurant> Restaurants { get; set; }
        public int Order { get; set; }
        public ApplicationUser User { get; set; }
        public UserVisitListListItemViewModel() { }

        public UserVisitListListItemViewModel(ApplicationDbContext context)
        {


        }

        public void Persist(UserVisitList newPlaceToVisit, ApplicationDbContext context)
        {
            //Models.UserVisitList userVisit = new Models.UserVisitList
            //{
            //    Id = RestaurantId,
               
            //};
            context.Update(newPlaceToVisit);
            context.SaveChanges();
        }

        public void AddItem(UserVisitList newPlaceToVisit, ApplicationDbContext context)
        {
            //Models.UserVisitList userVisit = new Models.UserVisitList
            //{
            //    Id = RestaurantId,

            //};
            context.Add(newPlaceToVisit);
            context.SaveChanges();
        }
    }
}
