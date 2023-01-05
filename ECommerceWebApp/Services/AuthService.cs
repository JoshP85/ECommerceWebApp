using ECommerceWebApp.Data;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class AuthService
    {

        private readonly DatabaseContext _databaseContext;

        public AuthService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddUser(RegisteredUser user)
        {
            var userinfo = new RegisteredUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                Phone = user.Phone,
            };
            _databaseContext.RegisteredUsers.Add(userinfo);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
