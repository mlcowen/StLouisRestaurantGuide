using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StLouisRestaurantGuide.Data;
using StLouisRestaurantGuide.Models;

namespace StLouisRestaurantGuide.ViewModels.Categories
{
    public class CategoryCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CategoryRestaurant> CategoryRestaurants { get; set; }


        internal void Persist(ApplicationDbContext context)
        {
            Category category = new Category
            {
                Id = this.Id,
                Name = this.Name,

            };

            context.Add(category);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw;
                //we need to tell userthe item exists already

            }

        }
    }
}
