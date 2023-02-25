using ECommerceWebApp.Models;

namespace ECommerceWebApp.ViewModels
{
    public class AccountDetailsViewModel
    {
        public Account Account { get; set; }
        public IEnumerable<Order> OrderHistory { get; set; }

    }
}
