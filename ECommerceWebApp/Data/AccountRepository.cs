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
