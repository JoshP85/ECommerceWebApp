using ECommerceWebApp.Models;
using System.Security.Policy;

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

    }
}
