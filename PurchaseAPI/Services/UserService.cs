using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PurchaseAPI.Data;
using PurchaseAPI.Entities;
using PurchaseAPI.Services.IServices;

namespace PurchaseAPI.Services
{
    public class UserService : IUser
    {
        private readonly PurchaseDbContext _context;
        public UserService(PurchaseDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<string> RegisterUsername(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "user Added Successfully";
        }
    }
}
