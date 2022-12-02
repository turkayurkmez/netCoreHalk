using eshop.Application.DTOs.Requests;
using eshop.Entities;

namespace eshop.Application
{
    public interface IProductService
    {
        Product GetProduct(int id);
        List<Product> GetProducts();
        List<Product> SearchProducstByCategoryId(int value);
        int CreateNewProduct(CreateNewProductRequest product);
        void UpdateProduct(UpdateExistingProductRequest product);
        void DeleteProductFromDb(int id);

        bool ProductIsExist(int id);

    }
}