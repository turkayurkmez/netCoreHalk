using eshop.DataAccess.Repositories;
using eshop.Entities;

namespace eshop.Application
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetAll();
        }
    }
}
