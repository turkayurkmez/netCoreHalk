using introduceMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace introduceMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Sehirler = new string[] { "Eskişehir", "İstanbul", "İzmir" };
            ViewBag.Ad = "Türkay Ürkmez";
            ViewBag.Saat = DateTime.Now.Hour;
            ViewBag.Sehir = "Eskişehir";

            var products = new List<Product>()
            {
                new() { Id=1, Name="Samsung", Description="Android", Price=1500},
                new() { Id=2, Name="IPhone", Description="IOS", Price=1500},
                new() { Id=3, Name="Huawei", Description="Android", Price=1500},

            };

            return View(products);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Connect()
        {
            return View();
        }
    }
}
