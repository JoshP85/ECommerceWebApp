using ECommerceWebApp.DTOs;
using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using ECommerceWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private string ShoppingCartId => HttpContext.Session.GetString(nameof(Account.ShoppingCartId));
        private string AccountId => HttpContext.Session.GetString(nameof(Account.AccountId));

        private readonly ShoppingCartService _shoppingCartService;
        private readonly ShoppingItemService _shoppingItemService;
        private readonly ProductService _productService;
        public ShoppingCartController(ShoppingCartService shoppingCartService, ShoppingItemService shoppingItemService, ProductService productService)
        {
            _shoppingCartService = shoppingCartService;
            _shoppingItemService = shoppingItemService;
            _productService = productService;
        }

        public async Task<IActionResult> ShoppingCart()
        {
            if (ShoppingCartId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ShoppingCartViewModel scvm = new()
            {
                ShoppingCart = await _shoppingCartService.GetShoppingCartById(ShoppingCartId),
            };

            return View(scvm);
        }

        public async Task<IActionResult> AddToCart(ShoppingItemDTO shoppingItem)
        {
            if (ModelState.IsValid)
            {
                shoppingItem.ShoppingCartId = ShoppingCartId;

                var result = await _shoppingCartService.AddToCart(shoppingItem);

                //TODO: Add error messages
                if (result is true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    return RedirectToAction("Index", "Home");
                }

            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(ShoppingItemDTO shoppingItemDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _shoppingCartService.RemoveFromCart(shoppingItemDTO);

                //TODO: Add error messages
                if (result is true)
                {
                    return RedirectToAction("ShoppingCart", "ShoppingCart");
                }
                else
                {

                    return RedirectToAction("ShoppingCart", "ShoppingCart");
                }
            }

            return RedirectToAction("ShoppingCart", "ShoppingCart");
        }
    }
}
