using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ShoppingCartService
    {
        private readonly IUnitOfWork<ShoppingCart> _unitOfWork;
        private readonly IUnitOfWork<ShoppingItem> _shoppingItemUnitOfWork;
        private readonly ProductService _productService;

        public ShoppingCartService(IUnitOfWork<ShoppingCart> unitOfWork, IUnitOfWork<ShoppingItem> shoppingItemUnitOfWork, ProductService productService)
        {
            _unitOfWork = unitOfWork;
            _shoppingItemUnitOfWork = shoppingItemUnitOfWork;
            _productService = productService;
        }

        public async Task<bool> AddToCart(ShoppingCart shoppingCart, ShoppingItem cartItem)
        {
            shoppingCart.CartItems.Add(cartItem);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public ShoppingCart GetShoppingCartById(string shoppingCartId)
        {
            return _unitOfWork.ShoppingCartRepository.GetShoppingCartById(shoppingCartId);
        }

        public decimal GetTotalCostOfCartItems(string cartId)
        {
            return _shoppingItemUnitOfWork.ShoppingItemRepository.GetTotalCostOfCartItems(cartId);
        }
    }
}
