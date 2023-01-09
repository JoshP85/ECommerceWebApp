using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly DatabaseContext _databaseContext;

        public AccountRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

    }
}
