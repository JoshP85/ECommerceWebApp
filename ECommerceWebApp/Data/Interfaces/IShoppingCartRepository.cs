using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data.Interfaces
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        public Task<ShoppingCart> GetShoppingCartById(string shoppingCartId);
    }
}