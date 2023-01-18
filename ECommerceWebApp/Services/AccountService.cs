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

        public async Task<string> CreateAccount(RegisterViewModel newAccount)
        {
            var newUserAccount = new Account
            {
                FirstName = newAccount.FirstName,
                LastName = newAccount.LastName,
                Email = newAccount.Email,
            };

            while (await _unitOfWork.AccountRepository.IsIdInUseAsync(newUserAccount.Id))
            {
                newUserAccount.Id = Guid.NewGuid().ToString();
            }


            await _unitOfWork.AccountRepository.AddAsync(newUserAccount);
            return newUserAccount.Id;
        }

        public async Task<bool> IsEmailInUseAsync(string email)
        {
            return await _unitOfWork.AccountRepository.IsEmailInUseAsync(email);
        }
    }
}

