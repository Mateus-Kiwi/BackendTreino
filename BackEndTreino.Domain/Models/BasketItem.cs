using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndTreino.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int QuantityStock { get; set; }
        public string ImgUrl { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
    }
}