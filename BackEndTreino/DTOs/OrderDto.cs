using BackEndTreino.DTOs;

namespace API.DTOs
{
    public class OrderDto
    {
        public string BuyerEmail { get; set; }
        public string basketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressDTO ShipToAddress { get; set; }
        public List<OrderItemDto>? Items { get; set; }
    }
}