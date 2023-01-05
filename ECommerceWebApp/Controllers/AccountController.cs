using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private readonly AuthService _userService;

        public AccountController(ILogger<HomeController> logger, AuthService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisteredUser user)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddUser(user);
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }
    }
}
