
namespace Prototype.Models
{
    public class User
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Info { get; set; } = "";

    }
}
