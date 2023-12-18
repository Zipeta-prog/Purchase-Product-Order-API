using PurchaseAPI.Models;

namespace PurchaseAPI.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Roles { get; set; } = "User";


        public List<Order> Orders { get; set; } = new List<Order>();
    }

}
