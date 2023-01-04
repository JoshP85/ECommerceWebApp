using System.ComponentModel.DataAnnotations;

namespace ECommerceWebApp.Models
{
    public class RegisteredUser
    {
        public RegisteredUser()
        {
            Id = Guid.NewGuid().ToString();
            Type = UserType.Customer;
        }

        public enum UserType
        {
            Customer,
            Employee,
            Admin
        }

        [Key]
        public string Id { get; set; }
        public UserType Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
