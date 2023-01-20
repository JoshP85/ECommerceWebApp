using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebApp.Data
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        private readonly DatabaseContext _context;

        public ProductCategoryRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ProductCategory> GetAllProducts() => _context.ProductCategories.Include(pc => pc.Products).ToList();

    }
}
