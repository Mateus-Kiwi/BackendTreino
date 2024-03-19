using System.ComponentModel.DataAnnotations;
using BackEndTreino.Models;

namespace BackEndTreino.DTOs
{
    public record BrandDTO
    (
        [Required]
        string? Name
    );
}
