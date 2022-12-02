using eshop.Application;
using eshop.Application.DTOs.Requests;
using eshop.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eshop.Web.Controllers
{
    [Authorize(Roles = "admin,editor")]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.categoryService = categoryService;
        }
        [HttpGet]

        public IActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }
        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.Categories = getCategoriesForView();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateNewProductRequest product)
        {
            if (ModelState.IsValid)
            {
                productService.CreateNewProduct(product);
                return RedirectToAction(nameof(Index));

            }
            ViewBag.Categories = getCategoriesForView();
            return View();
        }

        public IActionResult Edit(int id)
        {
            var product = productService.GetProduct(id);
            ViewBag.Categories = getCategoriesForView();
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(UpdateExistingProductRequest product)
        {
            if (ModelState.IsValid)
            {
                productService.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }

            return View();

        }

        public IActionResult Delete(int id)
        {
            Product product = productService.GetProduct(id);
            return View(product);
        }

        [HttpPost()]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            productService.DeleteProductFromDb(id);
            return RedirectToAction(nameof(Index));
        }

        private IEnumerable<SelectListItem> getCategoriesForView()
        {
            var selectList = categoryService.GetCategories()?.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            return selectList;

        }
    }
}
