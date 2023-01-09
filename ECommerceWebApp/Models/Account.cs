using System.ComponentModel.DataAnnotations;

namespace ECommerceWebApp.Models
{
    public class Account
    {
        public Account()
        {
            Id = Guid.NewGuid().ToString();
            Type = AccountType.Customer;
        }

        public enum AccountType
        {
            Customer,
            Employee,
            Admin
        }

        [Key]
        public string Id { get; set; }
        public AccountType Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
