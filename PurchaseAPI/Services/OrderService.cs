using Microsoft.EntityFrameworkCore;
using PurchaseAPI.Data;
using PurchaseAPI.Models;

namespace PurchaseAPI.Services.IServices
{
    public class OrderService : IOrder
    {
        private readonly PurchaseDbContext _dbContext;

        public OrderService(PurchaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // from interface
        public async Task<List<Order>> GetOrderListAsync()
        {
            return await _dbContext.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ToListAsync();
        }

        public async Task<Order> GetOrderAsync(Guid orderId)
        {
            return await _dbContext.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<string> PurchaseOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return "Order created successfully";
        }

        public async Task<string> UpdateOrder(Order order)
        {
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
            return "Order updated successfully";
        }

        public async Task<string> deleteOrder(Guid id)
        {
            var order = await GetOrderAsync(id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();

            }
            return "Order deleted successfully";
        }
    }
}
