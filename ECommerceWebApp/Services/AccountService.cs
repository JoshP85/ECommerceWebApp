using ECommerceWebApp.Data;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class AccountService
    {
        private readonly IUnitOfWork<Account> _unitOfWork;

        public AccountService(IUnitOfWork<Account> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Register(Account newAccount)
        {
            var newUserAccount = new Account
            {
                FirstName = newAccount.FirstName,
                LastName = newAccount.LastName,
                Email = newAccount.Email,
                Password = newAccount.Password,
            };

            _unitOfWork.AccountRepository.Add(newUserAccount);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

