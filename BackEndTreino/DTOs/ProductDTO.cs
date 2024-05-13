using BackEndTreino.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackEndTreino.DTOs
{
    public record ProductDTO
    (
        
        int Id,

        [Required]
        string? Name,

        [Required]
        string? Description,

        [Required]
        decimal Price,

        [Required]
        string? ImgUrl,

        [Required]
        float Inventory,

        int CategoryId,

        [property: JsonIgnore]
        string? CategoryName,  

        int BrandId,

        [property: JsonIgnore]
        string? BrandName

    );
}