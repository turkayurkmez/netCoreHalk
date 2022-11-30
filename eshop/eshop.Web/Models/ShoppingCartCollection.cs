using eshop.Entities;

namespace eshop.Web.Models
{
    public class ProductInCart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class ShoppingCartCollection
    {
        //JSON ile serialize edeceksek; önemli alanlar public olmalı
        public List<ProductInCart> Products = new List<ProductInCart>();
        public void AddToCard(Product product, int quantity)
        {
            //Eğer product daha önce eklenmiş ise; adedini arttır
            //                       aksi halde koleksiyona ekle                   

            var existingProduct = Products.FirstOrDefault(p => p.Product.Id == product.Id);
            if (existingProduct == null)
            {
                Products.Add(new ProductInCart { Product = product, Quantity = quantity });

            }
            else
            {
                existingProduct.Quantity += quantity;
            }
        }

        public void Clear() => Products.Clear();

        public decimal GetTotalPrice() => Products.Sum(p => p.Product.Price.Value * p.Quantity);

        public void RemoveProductInCard(int id) => Products.RemoveAll(p => p.Product.Id == id);

    }
}
