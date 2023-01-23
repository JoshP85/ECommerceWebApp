using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public class ShoppingItemRepository : Repository<ShoppingItem>, IShoppingItemRepository
    {
        private readonly DatabaseContext _context;
        public ShoppingItemRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}
