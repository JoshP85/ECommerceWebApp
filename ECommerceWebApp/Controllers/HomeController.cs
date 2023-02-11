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
        private readonly ProductService _productService;
        private readonly ProductCategoryService _productCategoryService;
        private readonly ShoppingCartService _shoppingCartService;
        private readonly ShoppingItemService _shoppingItemService;
        private string ShoppingCartId => HttpContext.Session.GetString(nameof(ShoppingCart.ShoppingCartId));
        public HomeController(ILogger<HomeController> logger, ProductService productService, ProductCategoryService productCategoryService, ShoppingCartService shoppingCartService, ShoppingItemService shoppingItemService)
        {
            _logger = logger;
            _productService = productService;
            _productCategoryService = productCategoryService;
            _shoppingCartService = shoppingCartService;
            _shoppingItemService = shoppingItemService;
        }

        public async Task<IActionResult> Index()
        {
            if (ShoppingCartId != null)
            {
                ShoppingCart shoppingCart = await _shoppingCartService.GetShoppingCartById(ShoppingCartId);

                List<string> cartItems = new();

                foreach (var item in shoppingCart.CartItems)
                {
                    cartItems.Add(item.ProductId);
                }
                IndexViewModel indexVMNUll = new()
                {
                    Categories = _productCategoryService.GetAllCategoriesWithProducts(),
                    CartItems = cartItems,
                };


                return View(indexVMNUll);
            }

            IndexViewModel indexVM = new()
            {
                Categories = _productCategoryService.GetAllCategoriesWithProducts(),
                CartItems = null,
            };

            return View(indexVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}