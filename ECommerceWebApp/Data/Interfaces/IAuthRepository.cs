using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data.Interfaces
{
    public interface IAuthRepository : IRepository<Auth>
    {

        public string GetPassword(string email);
    }
}