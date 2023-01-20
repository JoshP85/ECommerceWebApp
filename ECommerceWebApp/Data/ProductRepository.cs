using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DatabaseContext _context;
        public ProductRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}
