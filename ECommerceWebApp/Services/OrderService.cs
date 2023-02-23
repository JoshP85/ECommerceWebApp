using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork<Order> _unitOfWork;
        private readonly ShoppingItemService _shoppingItemService;
        public OrderService(IUnitOfWork<Order> unitOfWork, ShoppingItemService shoppingItemService)
        {
            _unitOfWork = unitOfWork;
            _shoppingItemService = shoppingItemService;
        }

        public async Task<IEnumerable<Order>> GetAllByAccountId(string accountId)
        {
            return await _unitOfWork.OrderRepository.GetAllByAccountId(accountId);
        }

        public void ConvertShoppingItemToOrder(Order order, ShoppingCart shoppingCart)
        {
            _shoppingItemService.ConvertShoppingItemToOrder(order, shoppingCart);
        }
    }
}
