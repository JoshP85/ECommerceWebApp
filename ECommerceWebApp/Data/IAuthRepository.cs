using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public interface IAuthRepository : IRepository<Auth>
    {

        public string GetPassword(string email);
    }
}