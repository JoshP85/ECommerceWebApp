using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebApp.Data
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly DatabaseContext _context;
        public ShoppingCartRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ShoppingCart> GetShoppingCartById(string shoppingCartId) =>
            await _context.ShoppingCarts
            .Where(sc => sc.ShoppingCartId == shoppingCartId)
            .Include(sc => sc.Account)
            .Include(sc => sc.CartItems)
            .ThenInclude(ci => ci.Product).FirstOrDefaultAsync();
    }
}
