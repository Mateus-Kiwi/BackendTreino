using BackEndTreino.EntityConfiguration;
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
            modelBuilder.ApplyConfiguration(new ProductConfig());
            // Adiciona os dados iniciais diretamente no método OnModelCreating
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Footwear", CategoryImgUrl = "https://cms-cdn.thesolesupplier.co.uk/2022/03/aj61.jpg.webp" },
                new Category { Id = 2, Name = "Pants", CategoryImgUrl = "https://www.realmenrealstyle.com/wp-content/uploads/2023/04/cargo_pants_lower_shot.jpg" },
                new Category { Id = 3, Name = "Hats", CategoryImgUrl = "https://brand.assets.adidas.com/f_auto,q_auto,fl_lossy/capi/enUS/Images/adidas-hat-size-masthead-c_221-990759.jpg" }
            );


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }

    }
}
