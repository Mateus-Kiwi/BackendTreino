using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BackEndTreino.Models
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string? Name { get; set; }
        [Required]
        [StringLength(250)]
        public string? ImgUrl { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
