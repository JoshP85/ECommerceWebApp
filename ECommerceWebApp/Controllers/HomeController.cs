using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerceWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;
        private readonly ProductCategoryService _productCategoryService;

        public HomeController(ILogger<HomeController> logger, ProductService productService, ProductCategoryService productCategoryService)
        {
            _logger = logger;
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        public IActionResult Index()
        {
            return View(_productCategoryService.GetAllProducts());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}