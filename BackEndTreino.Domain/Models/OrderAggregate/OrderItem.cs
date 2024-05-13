namespace Core.Entitites.OrderAggregate
{
    public class OrderItem
    {

        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered itemOrdered, decimal price, int quantity, int inventory)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
            Inventory = inventory;
        }


        public int Id { get; set; }
        public ProductItemOrdered ItemOrdered { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Inventory { get; set; }
    }
}