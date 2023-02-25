using ECommerceWebApp.Models;

namespace ECommerceWebApp.DTOs
{
    public class OrderDTO
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public Account Account { get; set; }
        public string AccountId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
