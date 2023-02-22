using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;
using ECommerceWebApp.ViewModels;

namespace ECommerceWebApp.Services
{
    public class AccountService
    {
        private readonly IUnitOfWork<Account> _unitOfWork;
        private readonly IUnitOfWork<Order> _unitOfWorkOrder;

        public AccountService(IUnitOfWork<Account> unitOfWork, IUnitOfWork<Order> unitOfWorkOrder)
        {
            _unitOfWork = unitOfWork;
            _unitOfWorkOrder = unitOfWorkOrder;
        }

        public async Task<Account> GetAccountById(string accountId)
        {
            return await _unitOfWork.AccountRepository.GetByIdAsync(accountId);
        }

        public async Task<Account> CreateAccount(RegisterViewModel newAccount)
        {
            var newUserAccount = new Account
            {
                FirstName = newAccount.FirstName,
                LastName = newAccount.LastName,
                Email = newAccount.Email,
            };

            // Make sure the new account has a unique Id, if not asign new Id.
            while (await _unitOfWork.AccountRepository.IsIdInUseAsync(newUserAccount.AccountId))
            {
                newUserAccount.AccountId = Guid.NewGuid().ToString();
            }

            await _unitOfWork.AccountRepository.AddAsync(newUserAccount);
            return newUserAccount;
        }

        // Checks if password and confirm password fields match
        public bool IsPasswordConfirmed(RegisterViewModel newAccount)
        {
            return newAccount.Password == newAccount.ConfirmPassword;
        }


        public async Task<bool> IsEmailInUseAsync(string email)
        {
            return await _unitOfWork.AccountRepository.IsEmailInUseAsync(email);
        }

        public async Task<bool> UpdateOrderHistory(Account account, Order order)
        {
            if (account.OrderHistory == null)
            {
                account.OrderHistory = new List<Order>();
            }

            account.OrderHistory.Add(order);
            await _unitOfWorkOrder.OrderRepository.AddAsync(order);
            _unitOfWork.AccountRepository.Update(account);

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task AddShoppingCartIdToAccount(string Id, string shoppingCartId)
        {
            Account account = await _unitOfWork.AccountRepository.GetByIdAsync(Id);
            account.ShoppingCartId = shoppingCartId;

            _unitOfWork.AccountRepository.Update(account);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Account> GetAllAccountData(string accountId)
        {
            return await _unitOfWork.AccountRepository.GetByIdAsync(accountId);
        }
    }
}

