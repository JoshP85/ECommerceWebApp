using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using ECommerceWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    public class AuthController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly AuthService _authService;
        private readonly AccountService _accountService;
        private string ShoppingCartId => HttpContext.Session.GetString(nameof(ShoppingCart.ShoppingCartId));
        public AuthController(ILogger<HomeController> logger, AuthService authService, AccountService accountService)
        {
            _logger = logger;
            _authService = authService;
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email, Password")] LoginViewModel newLogin)
        {
            if (newLogin != null)
            {
                if (ModelState.IsValid)
                {
                    Account account = await _authService.AttemptLoginAsync(newLogin);

                    if (account != null)
                    {
                        HttpContext.Session.SetString(nameof(Account.AccountId), account.AccountId);
                        HttpContext.Session.SetString(nameof(Account.FirstName), account.FirstName);
                        HttpContext.Session.SetString(nameof(Account.ShoppingCartId), account.ShoppingCartId);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("LoginError", "Incorrect email or password.");
                    }
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
