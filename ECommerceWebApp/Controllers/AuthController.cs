using ECommerceWebApp.Data;
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
            if (ModelState.IsValid)
            {
                //Account account = await _accountRepository.GetAccountByEmail(newLogin.Email);

                var result = await _authService.AuthenticateLogin(newLogin);
            }
            return View();
        }

    }
}
