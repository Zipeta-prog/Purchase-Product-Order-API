using Microsoft.Extensions.Logging;
using PurchaseAPI.Models;

namespace PurchaseAPI.Services.IServices
{
    public interface IProduct
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(Guid id);
        Task<string> AddProduct(Product product);

        Task<string> UpdateProduct(Product product);

        Task<bool> DeleteProduct(Guid id);
    }
}
