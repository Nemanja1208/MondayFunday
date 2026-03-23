using MondayFunday.Database;
using MondayFunday.Models;
using MondayFunday.Services.Interfaces;

namespace MondayFunday.Services.ProductService
{
    public class ProductServiceCRUD : IProductInterface
    {
        private readonly AppDbContext _context;

        public ProductServiceCRUD(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            // RETURN PRODUCTS FROM DB
            return  _context.Products.ToList();
        }
    }
}
