using eshop.Entities;

namespace eshop.DataAccess.Repositories
{
    public class FakeProductRepository : IProductRepository
    {

        private List<Product> _products;
        public FakeProductRepository()
        {
            _products = new List<Product>()
            {
                new Product{ Id=1, Name="Test Ürün 1", Price=5, Description="Test Data", ImageUrl="https://cdn.dsmcdn.com/ty117/product/media/images/20210524/17/91202408/70408992/1/1_org.jpg", Stock=100, Features="Test", CategoryId=1},
                new Product{ Id=2, Name="Test Ürün 2", Price=5, Description="Test Data", ImageUrl="https://cdn.dsmcdn.com/ty117/product/media/images/20210524/17/91202408/70408992/1/1_org.jpg", Stock=100, Features="Test", CategoryId=2},
                new Product{ Id=3, Name="Test Ürün 3", Price=5, Description="Test Data", ImageUrl="https://cdn.dsmcdn.com/ty117/product/media/images/20210524/17/91202408/70408992/1/1_org.jpg", Stock=100, Features="Test", CategoryId = 3},
                new Product{ Id=4, Name="Test Ürün 4", Price=5, Description="Test Data", ImageUrl="https://cdn.dsmcdn.com/ty117/product/media/images/20210524/17/91202408/70408992/1/1_org.jpg", Stock=100, Features="Test", CategoryId = 4},
                new Product{ Id=5, Name="Test Ürün 5", Price=5, Description="Test Data", ImageUrl="https://cdn.dsmcdn.com/ty117/product/media/images/20210524/17/91202408/70408992/1/1_org.jpg", Stock=100, Features="Test", CategoryId = 1},
                  new Product{ Id=6, Name="Test Ürün 1", Price=5, Description="Test Data", ImageUrl="https://cdn.dsmcdn.com/ty117/product/media/images/20210524/17/91202408/70408992/1/1_org.jpg", Stock=100, Features="Test", CategoryId = 2},
                new Product{ Id=7, Name="Test Ürün 2", Price=5, Description="Test Data", ImageUrl="https://cdn.dsmcdn.com/ty117/product/media/images/20210524/17/91202408/70408992/1/1_org.jpg", Stock=100, Features="Test", CategoryId = 3},
                new Product{ Id=8, Name="Test Ürün 3", Price=5, Description="Test Data", ImageUrl="https://cdn.dsmcdn.com/ty117/product/media/images/20210524/17/91202408/70408992/1/1_org.jpg", Stock=100, Features="Test", CategoryId = 4},
                new Product{ Id=9, Name="Test Ürün 4", Price=5, Description="Test Data", ImageUrl="https://cdn.dsmcdn.com/ty117/product/media/images/20210524/17/91202408/70408992/1/1_org.jpg", Stock=100, Features="Test" , CategoryId = 1},
                new Product{ Id=10, Name="Test Ürün 5", Price=5, Description="Test Data", ImageUrl="https://cdn.dsmcdn.com/ty117/product/media/images/20210524/17/91202408/70408992/1/1_org.jpg", Stock=100, Features="Test", CategoryId = 1},
                  new Product{ Id=10, Name="Test Ürün 5", Price=5, Description="Test Data", ImageUrl="https://cdn.dsmcdn.com/ty117/product/media/images/20210524/17/91202408/70408992/1/1_org.jpg", Stock=100, Features="Test", CategoryId = 1},
                    new Product{ Id=10, Name="Test Ürün 5", Price=5, Description="Test Data", ImageUrl="https://cdn.dsmcdn.com/ty117/product/media/images/20210524/17/91202408/70408992/1/1_org.jpg", Stock=100, Features="Test", CategoryId = 1},
            };
        }
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id) => _products.FirstOrDefault(p => p.Id == id);


        public IEnumerable<Product> GetAll()
        {
            return _products;


        }

        public bool IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> SearchProductsByCategoryId(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
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
