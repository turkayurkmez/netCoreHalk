using eshop.Application;
using eshop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {

                _categoryService.AddCategory(category);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
