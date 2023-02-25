using ECommerceWebApp.DTOs;
using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    public class OrderController : Controller
    {
        private string AccountId => HttpContext.Session.GetString(nameof(Account.AccountId));
        private string ShoppingCartId => HttpContext.Session.GetString(nameof(Account.ShoppingCartId));

        private readonly OrderService _orderService;
        private readonly ShoppingCartService _shoppingCartService;

        public OrderController(OrderService orderService, ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;

            _orderService = orderService;
        }

        public async Task<IActionResult> OrderSummery()
        {
            var orderSummery = await _orderService.GetOrderSummery(ShoppingCartId, AccountId);

            return View(orderSummery);
        }

        public async Task<IActionResult> FinaliseOrder(OrderDTO orderDTO)
        {
            await _orderService.CreateOrder(orderDTO);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult OrderComplete()
        {
            return View();
        }
    }
}
