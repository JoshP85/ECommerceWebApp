using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public interface IAccountRepository : IRepository<Account>
    {
        public Account GetAccountByEmail(string email);
        public bool IsEmailInUse(string email);
    }
}