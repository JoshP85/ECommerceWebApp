using ECommerceWebApp.Models;

namespace ECommerceWebApp.Data
{
    public class RegisteredUserRepository : IRegisteredUserRepository
    {
        private readonly DatabaseContext _context;

        public RegisteredUserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(RegisteredUser user)
        {
            _context.RegisteredUsers.Add(user);
        }

        public void Update(RegisteredUser user)
        {
            _context.RegisteredUsers.Update(user);
        }

        public void Delete(RegisteredUser user)
        {
            _context.RegisteredUsers.Remove(user);
        }

        public RegisteredUser Get(int id)
        {
            return _context.RegisteredUsers.Find(id);
        }

        public IEnumerable<RegisteredUser> GetAll()
        {
            return _context.RegisteredUsers.ToList();
        }
    }
}
