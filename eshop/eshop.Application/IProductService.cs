using eshop.Entities;

namespace eshop.Application
{
    public interface IProductService
    {
        Product GetProduct(int id);
        List<Product> GetProducts();
        List<Product> SearchProducstByCategoryId(int value);
    }
}