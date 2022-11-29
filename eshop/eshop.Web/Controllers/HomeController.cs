using eshop.Application;
using eshop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index(int? categoryId, int pageNo = 1)
        {

            var products = categoryId == null ? _productService.GetProducts() : _productService.SearchProducstByCategoryId(categoryId.Value);

            var totalItemsCount = products.Count;
            var itemsPerPage = 3;
            var totalPage = (int)Math.Ceiling((decimal)totalItemsCount / itemsPerPage);
            ViewBag.TotalPage = totalPage;
            ViewBag.CategoryId = categoryId;

            var paginatedProduct = products.OrderBy(p => p.Name)
                                           .Skip((pageNo - 1) * itemsPerPage)
                                           .Take(itemsPerPage)
                                           .ToList();

            return View(paginatedProduct);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}