using eshop.Application.DTOs.Requests;
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

        public int CreateNewProduct(CreateNewProductRequest product)
        {
            var productEntity = new Product
            {
                CategoryId = product.CategoryId,
                Description = product.Description,
                Features = product.Features,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
            _productRepository.Add(productEntity);
            return productEntity.Id;

        }
        public void UpdateProduct(UpdateExistingProductRequest updateRequest)
        {
            var product = new Product
            {
                Id = updateRequest.Id,
                CategoryId = updateRequest.CategoryId,
                Description = updateRequest.Description,
                Features = updateRequest.Features,
                ImageUrl = updateRequest.ImageUrl,
                Name = updateRequest.Name,
                Price = updateRequest.Price,
                Stock = updateRequest.Stock

            };
            _productRepository.Update(product);
        }

        public void DeleteProductFromDb(int id) => _productRepository.Delete(id);

        public bool ProductIsExist(int id)
        {
            return _productRepository.IsExists(id);
        }
    }
}
