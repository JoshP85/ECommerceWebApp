using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using ECommerceWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerceWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductCategoryService _productCategoryService;
        private readonly ShoppingCartService _shoppingCartService;

        private string ShoppingCartId => HttpContext.Session.GetString(nameof(ShoppingCart.ShoppingCartId));
        public HomeController(ILogger<HomeController> logger, ProductCategoryService productCategoryService, ShoppingCartService shoppingCartService)
        {
            _logger = logger;
            _productCategoryService = productCategoryService;
            _shoppingCartService = shoppingCartService;

        }

        public async Task<IActionResult> Index()
        {
            if (ShoppingCartId != null)
            {
                ShoppingCart shoppingCart = await _shoppingCartService.GetShoppingCartById(ShoppingCartId);

                int shoppingCartCount = await _shoppingCartService.CountTotalItemsInCart(ShoppingCartId);

                HttpContext.Session.SetInt32("CartItemCount", shoppingCartCount);

                List<string> cartItems = new();

                foreach (var item in shoppingCart.CartItems)
                {
                    cartItems.Add(item.ProductId);
                }
                IndexViewModel indexVM = new()
                {
                    Categories = _productCategoryService.GetAllCategoriesWithProducts(),
                    CartItems = cartItems,
                };


                return View(indexVM);
            }

            IndexViewModel indexVMNUll = new()
            {
                Categories = _productCategoryService.GetAllCategoriesWithProducts(),
                CartItems = null,
            };

            return View(indexVMNUll);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}