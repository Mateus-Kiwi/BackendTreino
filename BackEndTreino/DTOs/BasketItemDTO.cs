using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndTreino.DTOs
{
    public record BasketItemDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        [Required]
        public string Description { get; set; } 
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price is too low")]
        public decimal Price { get; set; }  
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity can't be lower than 1")]
        public int Quantity  { get; set; }
        [Required]
       
        public int Inventory  { get; set; }
        [Required]
        public string ImgUrl { get; set; }  
        [Required]
        public string BrandId { get; set; }
        [Required]
        public string CategoryId { get; set; }
    }
}