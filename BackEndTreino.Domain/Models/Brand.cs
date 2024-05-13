using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackEndTreino.Models
{
    public class Brand
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    
        public ICollection<Product>? Products { get; set; } = [];

        public void UpdateBrand(Brand brand)
        {
            Id = brand.Id;
            Name = brand.Name;
            Products = brand.Products;
        }
    }
}
