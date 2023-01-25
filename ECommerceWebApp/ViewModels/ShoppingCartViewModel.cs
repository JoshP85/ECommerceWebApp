using ECommerceWebApp.Models;

namespace ECommerceWebApp.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }

        public string CartId { get; set; }
        public virtual ICollection<ShoppingItem> CartItems { get; set; }
        public Account Account { get; set; }
        public string AccountId { get; set; }
        public decimal ItemTotalPrice { get; set; }
        public decimal CartTotalPrice { get; set; }





    }
}
