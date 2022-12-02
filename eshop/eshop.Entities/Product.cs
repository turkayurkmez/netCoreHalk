using System.ComponentModel.DataAnnotations;

namespace eshop.Entities
{
    public class Product : IEntity
    {
        public Product()
        {
            Category = null;
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adı boş olamaz")]
        [MaxLength(100)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Ürün açıklamasını tamamlayınız")]
        [MinLength(5, ErrorMessage = "Açıklama içerisinde en az 5 karakter olmalı")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public string? Features { get; set; }

        public Category? Category { get; set; }
        public int CategoryId { get; set; }

        //public DateTime CreatedDate { get; set; }


    }
}
