﻿using ECommerceWebApp.Data;
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

        public async Task<Account> AttemptLogin(LoginViewModel newLogin)
        {
            Account account = GetAccountByEmail(newLogin.Email);

            if (account != null)
            {
                Auth accountAuth = await GetAuthByIdAsync(account.Id);

                if (accountAuth != null && IsPasswordValid(accountAuth, newLogin.Password))
                    return account;
            }
            return null;
        }

        public Account GetAccountByEmail(string email)
        {
            return _unitOfWork.AccountRepository.GetAccountByEmail(email);
        }

        public async Task<Auth> GetAuthByIdAsync(string id)
        {
            return await _unitOfWork.AuthRepository.GetByIdAsync(id);
        }

        public bool IsPasswordValid(Auth accountAuth, string inputtedPassword)
        {
            return accountAuth.Password.Equals(inputtedPassword);
        }
    }
}
