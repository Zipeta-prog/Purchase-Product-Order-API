using PurchaseAPI.Entities;

namespace PurchaseAPI.Services.IServices
{
    public interface IJwt
    {
        string GenerateToken(User user);
    }
}
