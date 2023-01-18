using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public interface IAccountRepository : IRepository<Account>
    {
        //public Account GetAccountByEmail(string email);
        Task<Account> GetAccountByEmailAync(string email);
        public bool IsEmailInUse(string email);
    }
}