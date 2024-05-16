using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTreino.Models;

namespace BackEndTreino.Domain.Models
{
    public class Basket
    {
        public Basket()
        {
            
        }

        public Basket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public int? DeliveryMethodId { get; set; }
        public string? ClientSecret { get; set; }
        public string? PaymentIntentId { get; set; }
        // public decimal ShippingPrice { get; set; }

    }
}