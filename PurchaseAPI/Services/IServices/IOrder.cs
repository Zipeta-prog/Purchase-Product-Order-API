using PurchaseAPI.Models;
using System.Net.Sockets;

namespace PurchaseAPI.Services.IServices
{
    public interface IOrder
    {
        Task<List<Order>> GetOrderListAsync();

        Task<Order> GetOrderAsync(Guid orderId);

        Task<string> PurchaseOrder(Order order);

        Task<string> UpdateOrder(Order order);

        Task<string> deleteOrder(Guid id);
    }
}
