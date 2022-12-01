using eshop.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.DataAccess.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //Bu metodu hiç yazmasanız bile EF sizin için tabloları tasarlayabilir.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired()
                                                                .HasMaxLength(100);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(p => p.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Bilgisayar" },
                new Category { Id = 2, Name = "Ses Sistemleri" },
                new Category { Id = 3, Name = "Televizyon" },
                new Category { Id = 4, Name = "Ev Elektroniği" }


                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, Description = "Dell XPS Açıklama", Name = "Dell XPS 13", Price = 35000, Stock = 10, ImageUrl = "https://cdn03.ciceksepeti.com/cicek/kcm61759377-1/XL/dell-xps-13-9310-i7-1185g7-vpro-16gb-1tb-ssd-13.4-fhd-windows-10-pro-kcm61759377-1-54e81e24abbf459daed90890fb52d84e.jpg" },

               new Product { Id = 2, CategoryId = 1, Description = "Macbook", Name = "Macbook M2", Price = 75000, Stock = 10, ImageUrl = "https://cdn03.ciceksepeti.com/cicek/kcm61759377-1/XL/dell-xps-13-9310-i7-1185g7-vpro-16gb-1tb-ssd-13.4-fhd-windows-10-pro-kcm61759377-1-54e81e24abbf459daed90890fb52d84e.jpg" },

               new Product { Id = 3, CategoryId = 2, Description = "Sony 5+1", Name = "Sony", Price = 3500, Stock = 10, ImageUrl = "https://cdn03.ciceksepeti.com/cicek/kcm61759377-1/XL/dell-xps-13-9310-i7-1185g7-vpro-16gb-1tb-ssd-13.4-fhd-windows-10-pro-kcm61759377-1-54e81e24abbf459daed90890fb52d84e.jpg" },

               new Product { Id = 4, CategoryId = 2, Description = "Samsung Bar", Name = "BT Bar", Price = 10000, Stock = 10, ImageUrl = "https://cdn03.ciceksepeti.com/cicek/kcm61759377-1/XL/dell-xps-13-9310-i7-1185g7-vpro-16gb-1tb-ssd-13.4-fhd-windows-10-pro-kcm61759377-1-54e81e24abbf459daed90890fb52d84e.jpg" }
                );
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //burada db'nin nerede olacağı ve nasıl bağlanacağı bilgisi olacak!
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=HalkShopDb;Integrated Security=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }
    }
}
