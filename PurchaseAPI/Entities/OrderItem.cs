namespace PurchaseAPI.Models
{
    public class OrderItem
    {
        internal object UserId;

        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public object Orders { get; internal set; }
    }
}

