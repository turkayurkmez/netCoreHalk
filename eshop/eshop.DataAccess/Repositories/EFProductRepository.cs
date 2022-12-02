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
            shopDbContext.Products.Add(entity);
            shopDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = Get(id);
            shopDbContext.Products.Remove(product);
            shopDbContext.SaveChanges();
        }

        public Product Get(int id)
        {
            return shopDbContext.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return shopDbContext.Products.ToList();
        }

        public bool IsExists(int id)
        {
            return shopDbContext.Products.Any(p => p.Id == id);
        }

        public IEnumerable<Product> SearchProductsByCategoryId(int categoryName)
        {
            return shopDbContext.Products.Where(p => p.CategoryId == categoryName).ToList();
        }

        public IEnumerable<Product> SearchProductsByName(string name)
        {
            return shopDbContext.Products.Where(p => p.Name.Contains(name));
        }

        public void Update(Product entity)
        {
            //var existingProduct = shopDbContext.Products.Find(entity.Id);
            shopDbContext.Products.Update(entity);
            shopDbContext.SaveChanges();
        }
    }
}
