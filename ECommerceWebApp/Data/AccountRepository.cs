using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext _context;

        public AccountRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Account user)
        {
            _context.Accounts.Add(user);
        }

        public void Update(Account user)
        {
            _context.Accounts.Update(user);
        }

        public void Delete(Account user)
        {
            _context.Accounts.Remove(user);
        }

        public Account Get(int id)
        {
            return _context.Accounts.Find(id);
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }
    }
}
