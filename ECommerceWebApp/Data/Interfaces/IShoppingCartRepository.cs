using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data.Interfaces
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        public IEnumerable<ShoppingCart> GetShoppingCart(string shoppingCartId);
    }
}