using eshop.Entities;

namespace eshop.DataAccess.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> SearchProductsByName(string name);
        IEnumerable<Product> SearchProductsByCategoryId(int categoryName);
    }
}
