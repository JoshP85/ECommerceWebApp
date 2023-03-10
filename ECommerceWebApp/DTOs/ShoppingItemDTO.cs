namespace ECommerceWebApp.DTOs
{
    public class ShoppingItemDTO
    {
        public string ShoppingCartId { get; set; }
        public string ShoppingItemId { get; set; }
        public string ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int NewQuantity { get; set; }
        public int CurrentQuantity { get; set; }
    }
}
