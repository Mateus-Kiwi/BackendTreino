using BackEndTreino.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BackEndTreino.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adiciona os dados iniciais diretamente no método OnModelCreating
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Footwear", ImgUrl = "https://cms-cdn.thesolesupplier.co.uk/2022/03/aj61.jpg.webp" },
                new Category { Id = 2, Name = "Pants", ImgUrl = "https://www.realmenrealstyle.com/wp-content/uploads/2023/04/cargo_pants_lower_shot.jpg" },
                new Category { Id = 3, Name = "Hats", ImgUrl = "https://brand.assets.adidas.com/f_auto,q_auto,fl_lossy/capi/enUS/Images/adidas-hat-size-masthead-c_221-990759.jpg" }
            );

            //modelBuilder.Entity<Product>().HasData(
            //    new Product
            //    {
            //        Id = 1,
            //        Name = "Nike Sweatpants",
            //        Description = "Brown Nike jogger sweatpants",
            //        Price = 49.99M,
            //        ImgUrl = "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/380ab980-cc9d-4df8-bd6b-cb092b8d440c/solo-swoosh-mens-fleece-pants-JKRBBm.png",
            //        Inventory = 50,
            //        CreatedAt = DateTime.Now,
            //        CategoryId = 2
            //    },
            //    new Product
            //    {
            //        Id = 2,
            //        Name = "Adidas cap",
            //        Description = "White on black Adidas cap",
            //        Price = 19.99M,
            //        ImgUrl = "https://images.asos-media.com/products/adidas-sportswear-3-stripe-baseball-cap-in-black/204460713-1-black?$n_640w$&wid=513&fit=constrain",
            //        Inventory = 30,
            //        CreatedAt = DateTime.Now,
            //        CategoryId = 3
            //    },
            //    new Product
            //    {
            //        Id = 3,
            //        Name = "NB 550s",
            //        Description = "White and black New Balance 550s",
            //        Price = 109.99M,
            //        ImgUrl = "https://nb.scene7.com/is/image/NB/bb550ha1_nb_14_i?$pdpflexf2$&wid=440&hei=440",
            //        Inventory = 25,
            //        CreatedAt = DateTime.Now,
            //        CategoryId = 1
            //    }
            //);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}
