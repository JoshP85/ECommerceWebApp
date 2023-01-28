using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ShoppingCartService
    {
        private readonly IUnitOfWork<ShoppingCart> _unitOfWorkShoppingCart;
        private readonly IUnitOfWork<ShoppingItem> _unitOfWorkShoppingItem;
        private readonly ProductService _productService;
        private readonly ShoppingItemService _shoppingItemService;

        public ShoppingCartService(IUnitOfWork<ShoppingCart> unitOfWorkShoppingCart, IUnitOfWork<ShoppingItem> unitOfWorkshoppingItem, ProductService productService, ShoppingItemService shoppingItemService)
        {
            _unitOfWorkShoppingCart = unitOfWorkShoppingCart;
            _unitOfWorkShoppingItem = unitOfWorkshoppingItem;
            _productService = productService;
            _shoppingItemService = shoppingItemService;
        }

        public async Task<bool> AddToCart(string shoppingCartId, string productId)
        {
            ShoppingCart shoppingCart = GetShoppingCartById(shoppingCartId);
            if (shoppingCart == null)
            {
                return false;
            }

            Product product =
                await _productService.GetProductByIdAsync(productId);

            ShoppingItem shoppingItem =
                _shoppingItemService.GetItemFromCartByProductId(productId, shoppingCart);

            if (shoppingItem != null)
            {
                _shoppingItemService.UpdateShoppingItem(shoppingItem);
            }
            else
            {
                shoppingCart.CartItems.Add(
                    await _shoppingItemService.CreateShoppingItem(product, shoppingCart));
            }

            UpdateShoppingCartTotalPrice(shoppingCart, product.Price);

            await _unitOfWorkShoppingCart.SaveChangesAsync();

            return true;
        }

        public void UpdateShoppingCartTotalPrice(ShoppingCart shoppingCart, decimal productPrice)
        {
            shoppingCart.ShoppingCartTotalPrice += productPrice;
            _unitOfWorkShoppingCart.ShoppingCartRepository.Update(shoppingCart);
        }

        public ShoppingCart GetShoppingCartById(string shoppingCartId)
        {
            return _unitOfWorkShoppingCart.ShoppingCartRepository.GetShoppingCartById(shoppingCartId);
        }


    }
}
