using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllByAccountId(string accountId);
    }
}
