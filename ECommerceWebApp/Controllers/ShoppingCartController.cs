using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult ShoppingCart()
        {
            return View();
        }
    }
}
