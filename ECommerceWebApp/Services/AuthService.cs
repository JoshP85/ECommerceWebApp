using ECommerceWebApp.Data;
using ECommerceWebApp.Models;
using ECommerceWebApp.ViewModels;

namespace ECommerceWebApp.Services
{
    public class AuthService
    {
        private readonly IUnitOfWork<Auth> _unitOfWork;

        public AuthService(IUnitOfWork<Auth> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAuth(string id, string password)
        {
            var auth = new Auth
            {
                Id = id,
                Password = password
            };

            await _unitOfWork.AuthRepository.AddAsync(auth);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Account> AttemptLoginAsync(LoginViewModel newLogin)
        {
            var retrievedPassword = _unitOfWork.AuthRepository.GetPassword(newLogin.Email);

            if (retrievedPassword != null)
            {
                if (retrievedPassword.Equals(newLogin.Password))
                {
                    return await GetAccountByEmailAync(newLogin.Email);
                }
            }

            return null;
        }

        public async Task<Account> GetAccountByEmailAync(string email)
        {
            return await _unitOfWork.AccountRepository.GetAccountByEmailAync(email);
        }
    }
}
