using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebApp.Data
{
    public class ShoppingItemRepository : Repository<ShoppingItem>, IShoppingItemRepository
    {
        private readonly DatabaseContext _context;
        public ShoppingItemRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        //Not needed
        public async Task<decimal> GetTotalCostOfCartItems(string shoppingCartId) =>
            await _context.ShoppingItems.
            Where(i => i.ShoppingCartId == shoppingCartId).
            SumAsync(x => x.ShoppingItemTotalPrice);

        public bool IsProductAlreadyInCart(string productId, string shoppingCartId) =>
            _context.ShoppingItems.
            Where(i => i.ShoppingCartId == shoppingCartId).
            Select(p => p.ProductId).
            Contains(productId);

        public async Task<ShoppingItem> GetItemFromCartByProductId(string productId, string shoppingCartId) =>
            await _context.ShoppingItems.
            Where(i => i.ShoppingCartId == shoppingCartId &&
            i.ProductId == productId).FirstOrDefaultAsync();
    }
}
