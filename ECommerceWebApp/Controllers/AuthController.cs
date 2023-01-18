using ECommerceWebApp.Data;
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
        private readonly IAccountRepository _accountRepository;

        public AuthController(ILogger<HomeController> logger, AuthService authService, IAccountRepository accountRepository)
        {
            _logger = logger;
            _authService = authService;
            _accountRepository = accountRepository;
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
                        HttpContext.Session.SetString(nameof(Account.Id), account.Id);
                        HttpContext.Session.SetString(nameof(Account.FirstName), account.FirstName);

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
