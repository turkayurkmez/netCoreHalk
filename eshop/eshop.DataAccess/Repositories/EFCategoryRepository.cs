using eshop.DataAccess.Data;
using eshop.Entities;

namespace eshop.DataAccess.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext shopDbContext;

        public EFCategoryRepository(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext ?? throw new ArgumentNullException(nameof(shopDbContext));
        }

        public void Add(Category entity)
        {
            shopDbContext.Categories.Add(entity);
            shopDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            return shopDbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return shopDbContext.Categories.ToList();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
