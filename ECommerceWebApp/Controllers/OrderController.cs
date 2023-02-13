using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using ECommerceWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    public class OrderController : Controller
    {
        private string AccountId => HttpContext.Session.GetString(nameof(Account.AccountId));
        private string ShoppingCartId => HttpContext.Session.GetString(nameof(Account.ShoppingCartId));

        private readonly ShoppingCartService _shoppingCartService;
        private readonly AccountService _accountService;
        public OrderController(ShoppingCartService shoppingCartService, AccountService accountService)
        {
            _shoppingCartService = shoppingCartService;
            _accountService = accountService;
        }

        public async Task<IActionResult> OrderSummery()
        {
            OrderViewModel ovm = new()
            {
                ShoppingCart = await _shoppingCartService.GetShoppingCartById(ShoppingCartId),
                Account = await _accountService.GetAccountById(AccountId),
            };
            return View(ovm);
        }
    }
}
