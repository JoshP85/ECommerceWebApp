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

        public AccountController(ILogger<HomeController> logger, AccountService accountService, AuthService authService)
        {
            _logger = logger;
            _accountService = accountService;
            _authService = authService;
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
                if (_accountService.IsEmailInUse(newAccount.Email))
                {
                    ModelState.AddModelError("EmailError", $"The email \"{newAccount.Email}\" is already in use.");
                    return View(newAccount);
                }
                else
                {
                    string newAccountId = await _accountService.Register(newAccount);
                    await _authService.AddNewAuth(newAccountId, newAccount.Password);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(newAccount);
        }
    }
}
