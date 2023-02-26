using ECommerceWebApp.DTOs;
using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using ECommerceWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static ECommerceWebApp.ViewModels.ShoppingItemViewModel;

namespace ECommerceWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private string ShoppingCartId => HttpContext.Session.GetString(nameof(Account.ShoppingCartId));
        private string AccountId => HttpContext.Session.GetString(nameof(Account.AccountId));

        private readonly ShoppingCartService _shoppingCartService;
        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public async Task<IActionResult> ShoppingCart()
        {
            if (ShoppingCartId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            int shoppingCartCount = await _shoppingCartService.CountTotalItemsInCart(ShoppingCartId);

            HttpContext.Session.SetInt32("CartItemCount", shoppingCartCount);

            ShoppingCartViewModel scvm = new()
            {
                ShoppingCart = await _shoppingCartService.GetShoppingCartById(ShoppingCartId),
            };

            return View(scvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCart(ShoppingItemViewModel shoppingItem)
        {
            if (ModelState.IsValid)
            {
                ShoppingItemDTO shoppingItemDto = new()
                {
                    ShoppingItemId = shoppingItem.ShoppingItemId,
                    ShoppingCartId = ShoppingCartId,
                    ProductId = shoppingItem.ProductId,
                    Quantity = shoppingItem.Quantity,
                };

                switch (shoppingItem.Action)
                {
                    case ActionType.Add:
                        await _shoppingCartService.AddToCart(shoppingItemDto);
                        return RedirectToAction("Index", "Home");

                    case ActionType.Update:
                        await _shoppingCartService.UpdateCartItem(shoppingItemDto);
                        return RedirectToAction("ShoppingCart", "ShoppingCart");

                    case ActionType.Remove:
                        await _shoppingCartService.RemoveFromCart(shoppingItemDto);
                        return RedirectToAction("ShoppingCart", "ShoppingCart");

                    default:
                        ModelState.AddModelError("PageError", "Unexpected error. Please try again.");

                        TempData["PageError"] = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToList();
                        return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("PageError", "Unexpected error. Please try again.");

            TempData["PageError"] = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return RedirectToAction("Index", "Home");
        }
    }
}

