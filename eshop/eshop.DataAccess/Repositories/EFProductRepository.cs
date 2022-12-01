using eshop.DataAccess.Data;
using eshop.Entities;

namespace eshop.DataAccess.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ShopDbContext shopDbContext;

        public EFProductRepository(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext ?? throw new ArgumentNullException(nameof(shopDbContext));
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            return shopDbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return shopDbContext.Products.ToList();
        }

        public IEnumerable<Product> SearchProductsByCategoryId(int categoryName)
        {
            return shopDbContext.Products.Where(p => p.CategoryId == categoryName).ToList();
        }

        public IEnumerable<Product> SearchProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
