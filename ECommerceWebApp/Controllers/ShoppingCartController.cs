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
            var whatver = _shoppingCartService.GetShoppingCartById(ShoppingCartId);
            return View(whatver);
        }

        public async Task<IActionResult> AddToCart(string producId, decimal productPrice)
        {
            // Use later for logged out adding to cart func.
            /*if (AccountId == null)
            {
                var shoppingCart = _shoppingCartService.CreateShoppingCart();
                HttpContext.Session.SetString(nameof(Models.ShoppingCart.CartId), shoppingCart.CartId);
            }*/

            ShoppingCart shoppingCart = _shoppingCartService.GetShoppingCartById(ShoppingCartId);

            ShoppingItem item = await _shoppingCartService.CreateNewShoppingItem(producId, productPrice, ShoppingCartId);

            var result = await _shoppingCartService.AddToCart(ShoppingCartId, item);

            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
