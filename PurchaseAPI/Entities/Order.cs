using PurchaseAPI.Entities;

namespace PurchaseAPI.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
        public User Customer { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int OrderId { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public object CustomerName { get; internal set; }
    }
}
