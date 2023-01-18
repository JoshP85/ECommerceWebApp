using ECommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebApp.Data
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly DatabaseContext _context;

        public AccountRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        /*public AccountRepository(DatabaseContext context)
        {
            _context = context;
        }*/

        /*        public void Add(Account user)
                {
                    _databaseContext.Accounts.Add(user);
                }

                public void Update(Account user)
                {
                    _databaseContext.Accounts.Update(user);
                }

                public void Delete(Account user)
                {
                    _databaseContext.Accounts.Remove(user);
                }

                public Account Get(int id)
                {
                    return _databaseContext.Accounts.Find(id);
                }

                public IEnumerable<Account> GetAll()
                {
                    return _databaseContext.Accounts.ToList();
                }*/
        public async Task<Account> GetAccountByEmailAync(string email)
        {
            return await _context.Accounts.FirstOrDefaultAsync(_account => _account.Email == email);
        }

        public async Task<bool> IsEmailInUseAsync(string email)
        {
            return await _context.Accounts.AnyAsync(_account => _account.Email == email);
        }

        public async Task<bool> IsIdInUseAsync(string id)
        {
            return await _context.Accounts.AnyAsync(_account => _account.Id == id);
        }
    }
}
