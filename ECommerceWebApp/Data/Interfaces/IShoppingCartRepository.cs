using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data.Interfaces
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        public ShoppingCart GetShoppingCartById(string shoppingCartId);
    }
}