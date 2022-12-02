using eshop.Entities;

namespace eshop.DataAccess.Repositories
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return new List<Category>()
            {
                new Category{ Id=1, Name ="Elektronik"},
                new Category{ Id=2, Name ="Kozmetik"},
                new Category{ Id=3, Name ="Giyim"},
                new Category{ Id=4, Name ="Kırtasiye"},

            };
        }

        public bool IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
