using ECommerceWebApp.Models;

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
        public Account GetAccountByEmail(string email)
        {
            return _context.Accounts.FirstOrDefault(_account => _account.Email == email);
        }

        public bool IsEmailInUse(string email)
        {
            return _context.Accounts.Any(_account => _account.Email == email);
        }
    }
}
