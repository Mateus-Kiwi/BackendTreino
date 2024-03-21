using BackEndTreino.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackEndTreino.DTOs
{
    public record ProductDTO
    (

        string? Name,

        string? Description,

        decimal Price,

        string? ImgUrl,

        float Inventory,

        int CategoryId,

        int BrandId
    );
}