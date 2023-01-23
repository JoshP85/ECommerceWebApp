using System.ComponentModel.DataAnnotations;

namespace ECommerceWebApp.Models
{
    public class ShoppingCart
    {
        [Key]
        public string CartId { get; set; }
        public virtual ICollection<ShoppingItem> CartItems { get; set; } /*= new List<ShoppingItem>();*/
        public decimal TotalPrice { get; set; }
        public Account Account { get; set; }
        public string AccountId { get; set; }

    }
}
