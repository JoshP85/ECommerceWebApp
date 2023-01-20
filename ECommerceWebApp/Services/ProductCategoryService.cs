using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ProductCategoryService
    {
        private readonly IUnitOfWork<ProductCategory> _unitOfWork;

        public ProductCategoryService(IUnitOfWork<ProductCategory> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductCategory> GetAllCategoriesWithProducts() => _unitOfWork.ProductCategoryRepository.GetAllCategoriesWithProducts();
    }
}
