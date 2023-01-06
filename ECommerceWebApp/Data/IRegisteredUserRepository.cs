using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public interface IRegisteredUserRepository
    {
        void Add(RegisteredUser user);
        void Delete(RegisteredUser user);
        RegisteredUser Get(int id);
        IEnumerable<RegisteredUser> GetAll();
        void Update(RegisteredUser user);
    }
}