using BackEndTreino.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackEndTreino.DTOs
{
    public record ProductDTO
    (
        [Required]
        [StringLength(80)]
         string? Name,

        [Required]
        [StringLength(300)]
         string? Description,

        [Required]
        
         decimal Price,

        [Required]
        [StringLength(300)]
         string? ImgUrl,

         float Inventory,

        [Required]
        int CategoryId,


        [Required]
        int BrandId
    );
}