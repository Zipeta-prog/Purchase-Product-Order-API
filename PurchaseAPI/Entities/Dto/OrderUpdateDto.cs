namespace PurchaseAPI.Entities.Dto
{
    public class OrderUpdateDto
    {
        public object CustomerName { get; internal set; }
        public IEnumerable<object> OrderItems { get; internal set; }
    }
}
