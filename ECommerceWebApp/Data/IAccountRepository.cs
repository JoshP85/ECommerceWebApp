using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public interface IAccountRepository
    {
        void Add(Account user);
        void Delete(Account user);
        Account Get(int id);
        IEnumerable<Account> GetAll();
        void Update(Account user);
    }
}