using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.DTOs;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ShoppingItemService
    {
        private readonly IUnitOfWork<ShoppingItem> _unitOfWorkShoppingItem;

        public ShoppingItemService(IUnitOfWork<ShoppingItem> unitOfWorkshoppingItem)
        {
            _unitOfWorkShoppingItem = unitOfWorkshoppingItem;
        }

        public async Task<ShoppingItem> AddShoppingItemToCart(Product product, ShoppingCart shoppingCart)
        {
            ShoppingItem shoppingItem =
                GetItemFromCartByProductId(product.ProductId, shoppingCart);

            if (shoppingItem != null)
            {
                UpdateItemQuantityAndTotalPrice(shoppingItem, adjustQuantityBy: 1);
                return null;
            }
            else
            {
                return await CreateShoppingItem(product, shoppingCart);
            }
        }

        public async Task<bool> RemoveShoppingItemFromCart(ShoppingItemDTO shoppingItemDTO)
        {
            ShoppingItem shoppingItem =
                await GetShoppingItemById(shoppingItemDTO.ShoppingItemId);

            if (shoppingItem == null)
            {
                return false;
            }

            if (shoppingItem.Quantity <= 1)
            {
                _unitOfWorkShoppingItem.ShoppingItemRepository.Delete(shoppingItem);
                return true;
            }

            UpdateItemQuantityAndTotalPrice(shoppingItem, adjustQuantityBy: -1);

            _unitOfWorkShoppingItem.ShoppingItemRepository.Update(shoppingItem);

            return true;
        }

        public bool UpdateItemQuantityAndTotalPrice(ShoppingItem shoppingItem, int adjustQuantityBy)
        {
            shoppingItem.Quantity += adjustQuantityBy;
            shoppingItem.ShoppingItemTotalPrice = shoppingItem.Product.Price * shoppingItem.Quantity;

            _unitOfWorkShoppingItem.ShoppingItemRepository.Update(shoppingItem);
            return true;
        }

        public async Task<ShoppingItem> CreateShoppingItem(Product product, ShoppingCart shoppingCart)
        {
            ShoppingItem newShoppingItem = new(shoppingCart, product);

            await _unitOfWorkShoppingItem.ShoppingItemRepository.AddAsync(newShoppingItem);

            return newShoppingItem;
        }

        public ShoppingItem GetItemFromCartByProductId(string productId, ShoppingCart shoppingCart)
        {
            return shoppingCart.CartItems.
            Where(i => i.ProductId == productId).FirstOrDefault();
        }

        public async Task<ShoppingItem> GetShoppingItemById(string Id)
        {
            return await _unitOfWorkShoppingItem.ShoppingItemRepository.GetByIdAsync(Id);
        }


        public async Task<int> DeleteShoppingItem(ShoppingItemDTO shoppingItemDTO)
        {
            ShoppingItem shoppingItem =
                await GetShoppingItemById(shoppingItemDTO.ShoppingItemId);

            _unitOfWorkShoppingItem.ShoppingItemRepository.Delete(shoppingItem);

            return shoppingItem.Quantity;
        }
    }
}
