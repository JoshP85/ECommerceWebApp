using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private string ShoppingCartId => HttpContext.Session.GetString(nameof(Account.ShoppingCartId));
        private string AccountId => HttpContext.Session.GetString(nameof(Account.Id));

        private readonly ShoppingCartService _shoppingCartService;
        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult ShoppingCart()
        {
            return View(_shoppingCartService.GetShoppingCart(ShoppingCartId));
        }

        public async Task<IActionResult> AddToCart(string id, decimal price)
        {
            if (AccountId == null)
            {
                var shoppingCart = _shoppingCartService.CreateShoppingCart();
                HttpContext.Session.SetString(nameof(Models.ShoppingCart.CartId), shoppingCart.CartId);
            }



            ShoppingItem item = await _shoppingCartService.CreateNewShoppingItem(id, price, ShoppingCartId);

            var result = await _shoppingCartService.AddToCart(ShoppingCartId, item);

            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
