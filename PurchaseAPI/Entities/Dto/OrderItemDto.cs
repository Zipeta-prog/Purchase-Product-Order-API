using PurchaseAPI.Models;

namespace PurchaseAPI.Entities.Dto
{
    public class OrderItemDto
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public object Orders { get; internal set; }
    }
}
