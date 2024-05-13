using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackEndTreino.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string? Name { get; set; }

        [Required]
        [StringLength(300)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImgUrl { get; set; }
        [ForeignKey(nameof(Brand))]
        public required int BrandId { get; set; }

        [JsonIgnore]
        public Brand? Brand { get; set; }
        public string? BrandName { get; set; }

        public int Inventory { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(Category))]
        public required int CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }
        public string? CategoryName { get; set; }

        public void UpdateProduct(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            ImgUrl = product.ImgUrl;
            Inventory = product.Inventory;
            BrandId = product.BrandId;
            BrandName = product.BrandName;
            CategoryId = product.CategoryId;
            CategoryName = product.CategoryName;
        }

    }
}
