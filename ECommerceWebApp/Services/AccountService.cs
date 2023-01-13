using ECommerceWebApp.Data;
using ECommerceWebApp.Models;
using ECommerceWebApp.ViewModels;

namespace ECommerceWebApp.Services
{
    public class AccountService
    {
        private readonly IUnitOfWork<Account> _unitOfWork;

        public AccountService(IUnitOfWork<Account> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Register(RegisterViewModel newAccount)
        {
            var newUserAccount = new Account
            {
                FirstName = newAccount.FirstName,
                LastName = newAccount.LastName,
                Email = newAccount.Email,
            };

            await _unitOfWork.AccountRepository.AddAsync(newUserAccount);
            return newUserAccount.Id;
        }

        public bool IsEmailInUse(string email)
        {
            return _unitOfWork.AccountRepository.IsEmailInUse(email);
        }
    }
}

