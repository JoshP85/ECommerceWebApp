using ECommerceWebApp.Data;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class AuthService
    {
        private readonly IUnitOfWork<Auth> _unitOfWork;

        public AuthService(IUnitOfWork<Auth> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewAuth(string id, string password)
        {
            var auth = new Auth
            {
                Id = id,
                Password = password
            };

            await _unitOfWork.AuthRepository.AddAsync(auth);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task AuthenticateLogin(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
