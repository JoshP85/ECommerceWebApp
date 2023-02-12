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

        public async Task<bool> UpdateCartItem(ShoppingItemDTO shoppingItemDTO)
        {
            if (shoppingItemDTO.NewQuantity == 0)
            {
                await RemoveFromCart(shoppingItemDTO);
                return true;
            }

            if (shoppingItemDTO.NewQuantity == shoppingItemDTO.CurrentQuantity)
            {
                return true;
            }

            ShoppingCart shoppingCart =
                    await GetShoppingCartById(shoppingItemDTO.ShoppingCartId);

            if (shoppingItemDTO.NewQuantity > shoppingItemDTO.CurrentQuantity)
            {
                decimal newprice = shoppingItemDTO.ProductPrice * (shoppingItemDTO.NewQuantity - shoppingItemDTO.CurrentQuantity);
                UpdateShoppingCartTotalPrice(shoppingCart, newprice);
            }
            else if (shoppingItemDTO.NewQuantity < shoppingItemDTO.CurrentQuantity)
            {
                decimal newprice = shoppingItemDTO.ProductPrice * (shoppingItemDTO.CurrentQuantity - shoppingItemDTO.NewQuantity);
                UpdateShoppingCartTotalPrice(shoppingCart, -newprice);
            }

            _shoppingItemService.UpdateItemQuantityAndTotalPrice(await _shoppingItemService.GetShoppingItemById(shoppingItemDTO.ShoppingItemId), shoppingItemDTO.NewQuantity);

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

            UpdateShoppingCartTotalPrice(shoppingCart, -shoppingItemDTO.ProductPrice * shoppingItem.Quantity);

            await _unitOfWorkShoppingCart.SaveChangesAsync();

            return true;
        }

        public void UpdateShoppingCartTotalPrice(ShoppingCart shoppingCart, decimal updatedPriceOfItem)
        {
            shoppingCart.ShoppingCartTotalPrice += updatedPriceOfItem;

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
