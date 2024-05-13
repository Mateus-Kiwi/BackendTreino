using BackEndTreino.EntityConfiguration;
using BackEndTreino.Models;
using Core.Entitites.OrderAggregate;
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
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Nike"},
                new Brand { Id = 2, Name = "Adidas"},
                new Brand { Id = 3, Name = "New Balance"}
                
            );
            modelBuilder.Entity<DeliveryMethod>().HasData(
                new DeliveryMethod { Id = 1, ShortName = "Fast delivery", DeliveryTime = "1 day", Description = "Our own private delivery service guarantees you'll get your order within a day!", Price = 10},
                new DeliveryMethod { Id = 2, ShortName = "Normal delivery", DeliveryTime = "2-5 days", Description = "Standard mailing service, may take up to 5 days to deliver", Price = 0}
            );



            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

    }
}
