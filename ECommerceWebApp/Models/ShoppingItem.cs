namespace ECommerceWebApp.Models
{
    public class ShoppingItem
    {
        public string Id { get; set; }
        public Product Product { get; set; }
        public string ProductId { get; set; }
        public string ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
