using ECommerceWebApp.Attributes;

namespace ECommerceWebApp.ViewModels
{
    public class ShoppingItemViewModel
    {
        public enum ActionType
        {
            Add,
            Update,
            Remove
        }
        public string ShoppingItemId { get; set; }
        public string ShoppingCartId { get; set; }
        public string ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        [ValidAction(ActionType.Add, ActionType.Update, ActionType.Remove)]
        public ActionType Action { get; set; }
        public string Page { get; set; }// Used for displaying error message in the correct view.
    }
}
