using Bogus;
using MondayFunday.Models;

namespace MondayFunday.Database.DatabaseSeeder
{
    public static class SeedData
    {
        // Fixed seed = same data every build
        private const int Seed = 12345;

        public static List<Category> GetCategories()
        {
            var faker = new Faker<Category>()
                .UseSeed(Seed)
                .RuleFor(c => c.Id, f => f.IndexFaker + 1)
                .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);

            return faker.Generate(5);
        }

        public static List<Product> GetProducts(List<Category> categories)
        {
            var faker = new Faker<Product>()
                .UseSeed(Seed)
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => f.Finance.Amount(5, 999))
                .RuleFor(p => p.CategoryId, f => f.PickRandom(categories).Id);

            return faker.Generate(20);
        }

        public static List<Review> GetReviews(List<Product> products)
        {
            var faker = new Faker<Review>()
                .UseSeed(Seed)
                .RuleFor(r => r.Id, f => f.IndexFaker + 1)
                .RuleFor(r => r.ProductId, f => f.PickRandom(products).Id)
                .RuleFor(r => r.Comment, f => f.Rant.Review())
                .RuleFor(r => r.Rating, f => f.Random.Int(1, 5));

            return faker.Generate(50);
        }
    }
}
