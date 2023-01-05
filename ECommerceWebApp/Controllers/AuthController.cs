using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    public class AuthController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private readonly AuthService _userService;

        public AuthController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

    }
}
