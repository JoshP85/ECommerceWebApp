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
            var password = _unitOfWork.AuthRepository.GetPassword(newLogin.Email);
            if (password != null)
            {
                if (password.Equals(newLogin.Password))
                {
                    return await GetAccountByEmailAync(newLogin.Email);
                }
            }


            /*            Account account = await GetAccountByEmailAync(newLogin.Email);

                        if (account != null)
                        {
                            Auth accountAuth = await GetAuthByIdAsync(account.Id);

                            if (accountAuth != null && IsPasswordValid(accountAuth, newLogin.Password))
                                return account;
                        }*/
            return null;
        }

        public async Task<Account> GetAccountByEmailAync(string email)
        {
            return await _unitOfWork.AccountRepository.GetAccountByEmailAync(email);
        }

        /*        public async Task<Auth> GetAuthByIdAsync(string id)
                {
                    return await _unitOfWork.AuthRepository.GetByIdAsync(id);
                }*/

        /*        public bool IsPasswordValid(string accountAuth, string inputtedPassword)
                {
                    return accountAuth.Equals(inputtedPassword);
                }*/
    }
}
