using System.ComponentModel.DataAnnotations;

namespace ECommerceWebApp.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
        }

        public ShoppingCart(string cartId, Account account, string accountId)
        {
            ShoppingCartId = cartId;
            ShoppingCartTotalPrice = 0.00M;
            Account = account;
            AccountId = accountId;
        }

        [Key]
        public string ShoppingCartId { get; set; }
        public virtual ICollection<ShoppingItem> CartItems { get; set; } /*= new List<ShoppingItem>();*/
        public decimal ShoppingCartTotalPrice { get; set; }
        public Account Account { get; set; }
        public string AccountId { get; set; }

    }
}
