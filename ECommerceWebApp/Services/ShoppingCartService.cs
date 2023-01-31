using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.DTOs;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ShoppingCartService
    {
        private readonly IUnitOfWork<ShoppingCart> _unitOfWorkShoppingCart;
        private readonly ProductService _productService;
        private readonly ShoppingItemService _shoppingItemService;

        public ShoppingCartService(IUnitOfWork<ShoppingCart> unitOfWorkShoppingCart, ProductService productService, ShoppingItemService shoppingItemService)
        {
            _unitOfWorkShoppingCart = unitOfWorkShoppingCart;
            _productService = productService;
            _shoppingItemService = shoppingItemService;
        }

        public async Task<bool> AddToCart(ShoppingItemDTO shoppingItemDTO)
        {
            ShoppingCart shoppingCart = await GetShoppingCartById(shoppingItemDTO.ShoppingCartId);
            if (shoppingCart == null)
            {
                return false;
            }

            Product product =
                await _productService.GetProductByIdAsync(shoppingItemDTO.ProductId);

            ShoppingItem shoppingItem = await _shoppingItemService.AddShoppingItemToCart(product, shoppingCart);
            if (shoppingItem != null)
            {
                shoppingCart.CartItems.Add(shoppingItem);
            }

            UpdateShoppingCartTotalPrice(shoppingCart, shoppingItemDTO.ProductPrice);

            await _unitOfWorkShoppingCart.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveFromCart(ShoppingItemDTO shoppingItemDTO)
        {
            ShoppingCart shoppingCart =
                    await GetShoppingCartById(shoppingItemDTO.ShoppingCartId);

            if (await _shoppingItemService.RemoveShoppingItemFromCart(shoppingItemDTO))
            {
                UpdateShoppingCartTotalPrice(shoppingCart, -shoppingItemDTO.ProductPrice);

                await _unitOfWorkShoppingCart.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public void UpdateShoppingCartTotalPrice(ShoppingCart shoppingCart, decimal productPrice)
        {
            shoppingCart.ShoppingCartTotalPrice += productPrice;

            _unitOfWorkShoppingCart.ShoppingCartRepository.Update(shoppingCart);
        }

        public async Task<ShoppingCart> GetShoppingCartById(string shoppingCartId)
        {
            return await _unitOfWorkShoppingCart.ShoppingCartRepository.GetShoppingCartById(shoppingCartId);
        }
    }
}
