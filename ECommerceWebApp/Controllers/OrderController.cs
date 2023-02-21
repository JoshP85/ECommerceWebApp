using ECommerceWebApp.DTOs;
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
        private readonly ProductService _productService;
        public OrderController(ShoppingCartService shoppingCartService, AccountService accountService, ProductService productService)
        {
            _shoppingCartService = shoppingCartService;
            _accountService = accountService;
            _productService = productService;
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

        public async Task<IActionResult> FinaliseOrder(OrderDTO orderDTO)
        {
            ShoppingCart shoppingCart = await _shoppingCartService.GetShoppingCartById(ShoppingCartId);

            Account account = await _accountService.GetAccountById(AccountId);

            Address address = new()
            {
                Account = account,
                AccountId = AccountId,
                AddressLine1 = orderDTO.AddressLine1,
                AddressLine2 = orderDTO.AddressLine2,
                City = orderDTO.City,
                State = orderDTO.State,
                PostalCode = orderDTO.PostalCode,
                Country = orderDTO.Country,


            };
            Order order = new()
            {
                Account = account,
                OrderId = Guid.NewGuid().ToString(),
                AccountId = AccountId,
                ShippingAddress = address,
                OrderItems = shoppingCart.CartItems,
                OrderDate = DateTime.Now,
                TotalPrice = shoppingCart.ShoppingCartTotalPrice

            };

            _productService.UpdateProductQuantity(shoppingCart);

            _accountService.UpdateOrderHistory(account, order);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult OrderComplete()
        {
            return View();
        }
    }
}
