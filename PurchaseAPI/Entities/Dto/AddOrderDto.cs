
namespace PurchaseAPI.Entities.Dto
{
    public class AddOrderDto
    {
        public int CustomerId { get; set; }
        public User Customer { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int OrderId { get; set; }
        public object CustomerName { get; internal set; }
        public IEnumerable<object> OrderItems { get; internal set; }
    }
}
