﻿namespace ECommerceWebApp.Models
{
    public class Address
    {
        public string AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }

    }
}
