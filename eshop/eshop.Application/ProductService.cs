using eshop.DataAccess.Repositories;
using eshop.Entities;

namespace eshop.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(int id)
        {
            var product = _productRepository.Get(id);
            return product;
        }

        public List<Product> GetProducts()
        {
            var products = _productRepository.GetAll();
            return products.ToList();
        }

        public List<Product> SearchProducstByCategoryId(int value)
        {
            var products = _productRepository.SearchProductsByCategoryId(value);
            return products.ToList();
        }
    }
}
