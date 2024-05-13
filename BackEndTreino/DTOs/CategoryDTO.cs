using BackEndTreino.Models;
using System.ComponentModel.DataAnnotations;

namespace BackEndTreino.DTOs
{
    public record CategoryDTO
    (
        [Required]
        [StringLength(80)]
        string? Name,

        
        [StringLength(250)]
        string? CategoryImgUrl
    );

}
