using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StLouisRestaurantGuide.Models;

namespace StLouisRestaurantGuide.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> RestaurantReviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryRestaurant> CategoryRestaurants { get; set; }
        public DbSet<UserVisitList> UserVisitLists { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasIndex(m => m.Name)
                .IsUnique();

            base.OnModelCreating(builder);
        }
    }
}
