using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebApp.Data
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly DatabaseContext _context;
        public OrderRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

    }
}
