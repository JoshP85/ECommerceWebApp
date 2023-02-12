using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data.Interfaces
{
    public interface IShoppingItemRepository : IRepository<ShoppingItem>
    {
        public Task<decimal> GetTotalCostOfCartItems(string cartId);

        public bool IsProductAlreadyInCart(string productId, string shoppingCartId);
        public Task<ShoppingItem> GetItemFromCartByProductId(string productId, string shoppingCartId);
    }
}