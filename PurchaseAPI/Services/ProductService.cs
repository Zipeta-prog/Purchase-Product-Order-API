using Microsoft.EntityFrameworkCore;
using PurchaseAPI.Data;
using PurchaseAPI.Models;

namespace PurchaseAPI.Services.IServices
{
    public class ProductService : IProduct
    {
        private readonly PurchaseDbContext _dbContext;

        public ProductService(PurchaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
       
        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<string> AddProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return "Product created successfully";
        }

        public async Task<string> UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return "Product updated succefully";
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await GetProduct(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
