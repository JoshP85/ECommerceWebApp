using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly DatabaseContext _context;
        public ShoppingCartRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }


    }
}
