namespace ECommerceWebApp.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public string AddressId { get; set; }
        public virtual ICollection<ShoppingItem> OrderItems { get; set; }
        public string OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
