using Microsoft.EntityFrameworkCore;
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
        
    }

}
