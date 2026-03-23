using MondayFunday.Models;

namespace MondayFunday.Services.Interfaces
{
    public interface IProductInterface
    {
        public IEnumerable<Product> GetProducts();

    }
}
