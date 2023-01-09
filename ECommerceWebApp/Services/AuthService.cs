﻿using ECommerceWebApp.Data;
using ECommerceWebApp.Models;
using ECommerceWebApp.ViewModels;

namespace ECommerceWebApp.Services
{
    public class AuthService
    {
        private readonly IUnitOfWork<Auth> _unitOfWork;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthRepository _authRepository;

        public AuthService(IUnitOfWork<Auth> unitOfWork, IAccountRepository accountRepository, IAuthRepository authRepository)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
            _authRepository = authRepository;
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

        public async Task<bool> AuthenticateLogin(LoginViewModel newLogin)
        {
            Account account = _accountRepository.GetAccountByEmail(newLogin.Email);
            if (account == null) return false;

            Auth auth = await _authRepository.GetByIdAsync(account.Id);
            if (auth == null) return false;

            if (auth.Password == newLogin.Password)
            {
                return true;
            }
            return false;
        }
    }
}
