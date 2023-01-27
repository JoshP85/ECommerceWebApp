﻿using ECommerceWebApp.Models;
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

        public IActionResult ShoppingCart()
        {
            var cart = _shoppingCartService.GetShoppingCartById(ShoppingCartId);
            ShoppingCartViewModel scvm = new()
            {
                CartId = cart.ShoppingCartId,
                CartItems = cart.CartItems,
                Account = cart.Account,
                AccountId = cart.AccountId,
                ShoppingCartTotalPrice = cart.ShoppingCartTotalPrice,
            };

            return View(scvm);
        }

        public async Task<IActionResult> AddToCart(string productId, decimal productPrice)
        {
            var result = await _shoppingCartService.AddToCart(ShoppingCartId, productId);

            return RedirectToAction("Index", "Home");
        }
    }
}
