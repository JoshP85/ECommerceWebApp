namespace ECommerceWebApp.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }
        public string ShippingAddress { get; set; }
        public virtual ICollection<ShoppingItem> OrderItems { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
