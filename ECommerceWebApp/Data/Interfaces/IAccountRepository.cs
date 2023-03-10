using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetAccountByEmailAync(string email);
        Task<bool> IsEmailInUseAsync(string email);
        Task<bool> IsIdInUseAsync(string id);
        Task<IEnumerable<Account>> GetAllAccountData(string accountId);
    }
}