

using System.ComponentModel.DataAnnotations;

namespace ECommerceWebApp.Models
{
    public class ShoppingItem
    {
        public ShoppingItem()
        {
        }

        public ShoppingItem(ShoppingCart shoppingCart, Product product)
        {
            ShoppingItemId = Guid.NewGuid().ToString();
            ShoppingCart = shoppingCart;
            ShoppingCartId = shoppingCart.ShoppingCartId;
            Product = product;
            ProductId = product.ProductId;
            Quantity = 1;
            ShoppingItemTotalPrice = product.Price;
        }

        [Key]
        public string ShoppingItemId { get; set; }
        public Product Product { get; set; }
        public string ProductId { get; set; }
        public string ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal ShoppingItemTotalPrice { get; set; }

    }
}
