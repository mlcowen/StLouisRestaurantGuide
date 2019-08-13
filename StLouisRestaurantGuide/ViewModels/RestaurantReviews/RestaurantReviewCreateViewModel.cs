using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StLouisRestaurantGuide.Data;
using StLouisRestaurantGuide.Models;

namespace StLouisRestaurantGuide.ViewModels.RestaurantReviews
{
    public class RestaurantReviewCreateViewModel
    {
        public int RestaurantId { get; set; }
        public string ReviewHeadline { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        internal void Persist(ApplicationDbContext context)
        {
            RestaurantReview review = new RestaurantReview
            {
                RestaurantId = this.RestaurantId,
                ReviewHeadline = this.ReviewHeadline,
                Rating = this.Rating,
                Review = this.Review
            };

            context.Add(review);
            context.SaveChanges();
        }
    }
}
