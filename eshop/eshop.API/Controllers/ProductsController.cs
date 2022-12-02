using eshop.Application;
using eshop.Application.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = productService.GetProduct(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();

        }
        [HttpGet("category/{categoryId}")]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            var products = productService.SearchProducstByCategoryId(categoryId);
            return products == null ? NotFound() : Ok(products);
        }
        [HttpPost]
        public IActionResult AddProduct(CreateNewProductRequest product)
        {
            if (ModelState.IsValid)
            {
                var lastId = productService.CreateNewProduct(product);
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id = lastId }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, UpdateExistingProductRequest request)
        {
            if (productService.ProductIsExist(id))
            {
                if (ModelState.IsValid)
                {
                    productService.UpdateProduct(request);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            return NotFound(new { message = $"{id} id'li ürün veritabanında yok!" });
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            if (productService.ProductIsExist(id))
            {
                productService.DeleteProductFromDb(id);
                return Ok(new { message = $"{id} id'li ürün başarıyla silindi!" });
            }
            return NotFound(new { message = $"{id} id'li ürün veritabanında yok!" });
        }
    }
}
