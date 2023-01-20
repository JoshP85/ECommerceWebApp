using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork<Product> _unitOfWork;

        public ProductService(IUnitOfWork<Product> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
