namespace ECommerceWebApp.Models
{
    public class ShoppingCart
    {
        public string Id { get; set; }
        public ICollection<ShoppingItem> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
        public Account Account { get; set; }
        public string AccountId { get; set; }

    }
}
