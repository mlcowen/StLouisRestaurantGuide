using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StLouisRestaurantGuide.Data;
using StLouisRestaurantGuide.Models;
using StLouisRestaurantGuide.ViewModels.Categories;

namespace StLouisRestaurantGuide.Controllers
{
    public class CategoryController
    {
        private ApplicationDbContext context;

        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //public IActionResult Index()
        //{

            //List<CategoryListItemViewModel> categories = CategoryListItemViewModel.GetCategories(context);
            //return View(categories);

        //}
    }
}
