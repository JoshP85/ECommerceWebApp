using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using ECommerceWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AccountService _accountService;
        private readonly AuthService _authService;
        private readonly ShoppingCartService _shoppingCartService;

        public AccountController(ILogger<HomeController> logger, AccountService accountService, AuthService authService, ShoppingCartService shoppingCartService)
        {
            _logger = logger;
            _accountService = accountService;
            _authService = authService;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newAccount)
        {
            if (ModelState.IsValid)
            {
                // If password and confirm password fields do not match return model error.
                if (!_accountService.IsPasswordConfirmed(newAccount))
                {
                    ModelState.AddModelError("PasswordError", $"Confirm password and password must match.");
                    return View(newAccount);
                }

                if (await _accountService.IsEmailInUseAsync(newAccount.Email))
                {
                    ModelState.AddModelError("EmailError", $"The email \"{newAccount.Email}\" is already in use.");
                    return View(newAccount);
                }

                else
                {
                    Account newUserAccount = await _accountService.CreateAccount(newAccount);

                    await _authService.CreateAuth(newUserAccount.AccountId, newAccount.Password);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(newAccount);
        }
    }
}
