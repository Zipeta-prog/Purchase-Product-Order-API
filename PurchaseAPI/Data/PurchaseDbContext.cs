using Microsoft.EntityFrameworkCore;
using PurchaseAPI.Entities;
using PurchaseAPI.Models;

namespace PurchaseAPI.Data
{
    public class PurchaseDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(u => u.Order)
                .HasForeignKey(o => o.UserId);
                //.WithOne(oi => oi.Order);

            modelBuilder.Entity<OrderItem>();
                
                
                

            base.OnModelCreating(modelBuilder);
        }
    }
}
