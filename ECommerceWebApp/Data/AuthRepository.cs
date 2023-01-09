using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public class AuthRepository : Repository<Auth>, IAuthRepository
    {
        private readonly DatabaseContext _databaseContext;
        public AuthRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Account GetAccountByEmail(Account account)
        {
            throw new NotImplementedException();
        }

        public Account GetPasswordByEmail()
        {
            throw new NotImplementedException();
        }
    }
}
