using eshop.Entities;

namespace eshop.DataAccess.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);

    }
}
