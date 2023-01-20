using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ShoppingCartService
    {
        private readonly IUnitOfWork<ShoppingCart> _unitOfWork;

        public ShoppingCartService(IUnitOfWork<ShoppingCart> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
