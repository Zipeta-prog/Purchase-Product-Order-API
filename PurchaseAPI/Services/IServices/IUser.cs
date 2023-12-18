using PurchaseAPI.Entities;

namespace PurchaseAPI.Services.IServices
{
    public interface IUser
    {
        Task<User> GetUserByEmail(string email);
        Task<string> RegisterUsername(User user);
    }
}
