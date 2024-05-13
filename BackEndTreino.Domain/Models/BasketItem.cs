using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackEndTreino.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public string ImgUrl { get; set; }
        public required int BrandId { get; set; }
        [JsonIgnore]
        public Brand? Brand { get; set; }
        public string? BrandName { get; set; }
        public required int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        public string? CategoryName { get; set; }
    }
}