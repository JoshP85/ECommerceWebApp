using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public class AuthRepository : Repository<Auth>, IAuthRepository
    {
        private readonly DatabaseContext _context;
        public AuthRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public string GetPassword(string providedEmail)
        {
            var password = (from a in _context.Accounts
                            join b in _context.AuthItems on a.Id equals b.Id
                            where a.Email == providedEmail
                            select b.Password).FirstOrDefault();

            return password;
        }
    }
}
