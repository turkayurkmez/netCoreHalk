using eshop.Application;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Web.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public MenuViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }
    }
}
