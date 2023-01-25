using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data.Interfaces
{
    public interface IShoppingItemRepository : IRepository<ShoppingItem>
    {
        public decimal GetTotalCostOfCartItems(string cartId);

        public bool IsProductAlreadyInCart(string productId, string shoppingCartId);
        public Task<ShoppingItem> GetProductAlreadyInCart(string productId, string shoppingCartId);
    }
}