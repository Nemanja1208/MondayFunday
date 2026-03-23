using Microsoft.EntityFrameworkCore;
using MondayFunday.Database.DatabaseSeeder;
using MondayFunday.Models;

namespace MondayFunday.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // TABLES
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }

        // Connection String


        // On model creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categories = SeedData.GetCategories();
            var products = SeedData.GetProducts(categories);
            var reviews = SeedData.GetReviews(products);

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Review>().HasData(reviews);
        }

    }

}
