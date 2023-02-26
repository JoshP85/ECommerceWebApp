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

        public async Task<bool> AddToCart(ShoppingItemDTO shoppingItemDto)
        {
            ShoppingCart shoppingCart = await GetShoppingCartById(shoppingItemDto.ShoppingCartId);

            if (shoppingCart == null)
            {
                return false;
            }

            Product product =
                await _productService.GetProductByIdAsync(shoppingItemDto.ProductId);

            ShoppingItem shoppingItem = await _shoppingItemService.CreateShoppingItem(product, shoppingCart);

            if (shoppingItem != null)
            {
                shoppingCart.CartItems.Add(shoppingItem);
            }

            CalculateCartTotalPrice(shoppingCart);

            await _unitOfWorkShoppingCart.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateCartItem(ShoppingItemDTO shoppingItemDTO)
        {
            if (shoppingItemDTO.Quantity == 0)
            {
                await RemoveFromCart(shoppingItemDTO);
                return true;
            }

            ShoppingCart shoppingCart =
                    await GetShoppingCartById(shoppingItemDTO.ShoppingCartId);

            ShoppingItem shoppingItem = shoppingCart.CartItems.Where(ci => ci.ShoppingItemId == shoppingItemDTO.ShoppingItemId).FirstOrDefault();

            shoppingItem.Quantity = shoppingItemDTO.Quantity;

            CalculateCartTotalPrice(shoppingCart);

            _shoppingItemService.UpdateItemQuantityAndTotalPrice(await _shoppingItemService.GetShoppingItemById(shoppingItemDTO.ShoppingItemId), shoppingItemDTO.Quantity);

            _unitOfWorkShoppingCart.ShoppingCartRepository.Update(shoppingCart);

            await _unitOfWorkShoppingCart.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveFromCart(ShoppingItemDTO shoppingItemDTO)
        {
            ShoppingCart shoppingCart =
                    await GetShoppingCartById(shoppingItemDTO.ShoppingCartId);

            ShoppingItem shoppingItem =
                await _shoppingItemService.GetShoppingItemById(shoppingItemDTO.ShoppingItemId);

            _shoppingItemService.DeleteShoppingItem(shoppingItem);

            shoppingCart.CartItems.Remove(shoppingItem);

            CalculateCartTotalPrice(shoppingCart);

            await _unitOfWorkShoppingCart.SaveChangesAsync();

            return true;
        }

        public void CalculateCartTotalPrice(ShoppingCart shoppingCart)
        {
            shoppingCart.ShoppingCartTotalPrice = shoppingCart.CartItems.Sum(ci => ci.Product.Price * ci.Quantity);

            _unitOfWorkShoppingCart.ShoppingCartRepository.Update(shoppingCart);
        }

        public async Task<ShoppingCart> GetShoppingCartById(string shoppingCartId)
        {
            return await _unitOfWorkShoppingCart.ShoppingCartRepository.GetShoppingCartById(shoppingCartId);
        }

        public async Task<int> CountTotalItemsInCart(string shoppingCartId)
        {
            var shoppingCart = await GetShoppingCartById(shoppingCartId);

            int shoppingCartCount = 0;
            foreach (var item in shoppingCart.CartItems)
            {
                shoppingCartCount += item.Quantity;
            }
            return shoppingCartCount;
        }
    }
}
