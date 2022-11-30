using eshop.Application;
using eshop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eshop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService productService;

        public ShoppingCartController(IProductService productService)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public IActionResult Index()
        {
            var shoppingCart = getCollectionFromSession();
            return View(shoppingCart);
        }

        public IActionResult AddProduct(int id)
        {
            var product = productService.GetProduct(id);
            if (product != null)
            {
                ShoppingCartCollection cartCollection = getCollectionFromSession();
                cartCollection.AddToCard(product, 1);
                saveToSession(cartCollection);
            }
            return Json(new { message = $"{id} değeri sunucuya ulaştı!" });
        }

        private void saveToSession(ShoppingCartCollection cartCollection)
        {
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartCollection));
        }

        private ShoppingCartCollection getCollectionFromSession()
        {
            //Eğer ilk kez sepete ürün ekleniyorsa;
            //ShoppingCartCollection nesnesini oluştur ve session nesnesine kaydet.
            //Daha önce sepete ürün eklenmiş ise; o zaman session nesnesinden ShoppingCart'ı oku.
            ShoppingCartCollection shoppingCartCollection = null;
            if (HttpContext.Session.GetString("cart") == null)
            {
                shoppingCartCollection = new ShoppingCartCollection();
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(shoppingCartCollection));

            }

            string serialized = HttpContext.Session.GetString("cart");
            var registeredShoppingCard = JsonConvert.DeserializeObject<ShoppingCartCollection>(serialized);
            return registeredShoppingCard;


        }
    }
}
