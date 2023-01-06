using ECommerceWebApp.Data;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class AccountService
    {
        private readonly IUnitOfWork<RegisteredUser> _unitOfWork;

        public AccountService(IUnitOfWork<RegisteredUser> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Register(UnregisteredUser newAccount)
        {
            var newUserAccount = new RegisteredUser
            {
                FirstName = newAccount.FirstName,
                LastName = newAccount.LastName,
                Email = newAccount.Email,
                Password = newAccount.Password,
            };

            _unitOfWork.RegisteredUserRepository.Add(newUserAccount);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

