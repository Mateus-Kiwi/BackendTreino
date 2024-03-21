using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndTreino.Models.Identity
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
        public int DeliveryMethod { get; set; }
        public string ClientSercret { get; set; }
        public string PaymentId { get; set; }
        public decimal ShippingPrice { get; set; }
    
    }
}