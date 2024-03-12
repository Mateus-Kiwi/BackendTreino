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

        //[Required]
        //[StringLength(80)]
        //public string BrandName { get; set; }

        //[Required]
        //public int BrandId { get; set; }
        [Required]
        public Brand Brand { get; set; }
        public float Inventory { get; set; }

        public DateTime CreatedAt  { get; set; }

        [Range(1, 3)]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
