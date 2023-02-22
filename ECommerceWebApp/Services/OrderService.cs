using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork<Order> _unitOfWork;
        public OrderService(IUnitOfWork<Order> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> GetAllByAccountId(string accountId)
        {
            return await _unitOfWork.OrderRepository.GetAllByAccountId(accountId);
        }
    }
}
