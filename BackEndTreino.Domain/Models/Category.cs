using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BackEndTreino.Models
{
    public class Category
    {

        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        
        [StringLength(250)]
        public string? CategoryImgUrl { get; set; }

        public ICollection<Product>? Products { get; set; } = [];

        public void UpdateCategory(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
    }
}
 