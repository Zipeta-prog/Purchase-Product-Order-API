namespace PurchaseAPI.Entities.Dto
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public Guid ProductId { get; set; }
    }
}
