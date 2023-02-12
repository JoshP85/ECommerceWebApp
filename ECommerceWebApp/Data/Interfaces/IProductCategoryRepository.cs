using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data.Interfaces
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        public IEnumerable<ProductCategory> GetAllCategoriesWithProducts();
    }
}
