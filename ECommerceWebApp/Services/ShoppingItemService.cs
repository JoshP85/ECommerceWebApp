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

        public ShoppingItem GetItemFromCartByProductId(string productId, ShoppingCart shoppingCart)
        {
            return shoppingCart.CartItems.
            Where(i => i.ProductId == productId).FirstOrDefault();
        }

        public bool UpdateShoppingItem(ShoppingItem shoppingItem)
        {
            shoppingItem.Quantity += 1;
            shoppingItem.ShoppingItemTotalPrice = shoppingItem.Product.Price * shoppingItem.Quantity;

            _unitOfWorkShoppingItem.ShoppingItemRepository.Update(shoppingItem);
            return true;
        }

        public async Task<bool> RemoveShoppingItem(ShoppingItemDTO shoppingItemDTO)
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

            shoppingItem.Quantity -= 1;
            shoppingItem.ShoppingItemTotalPrice -= shoppingItemDTO.ProductPrice;

            _unitOfWorkShoppingItem.ShoppingItemRepository.Update(shoppingItem);

            return true;
        }

        public async Task<ShoppingItem> CreateShoppingItem(Product product, ShoppingCart shoppingCart)
        {
            ShoppingItem newShoppingItem = new(shoppingCart, product);

            await _unitOfWorkShoppingItem.ShoppingItemRepository.AddAsync(newShoppingItem);

            return newShoppingItem;
        }

        // Not needed
        public decimal GetTotalCostOfCartItems(string cartId)
        {
            return _unitOfWorkShoppingItem.ShoppingItemRepository.GetTotalCostOfCartItems(cartId);
        }

        public async Task<ShoppingItem> GetShoppingItemById(string Id)
        {
            return await _unitOfWorkShoppingItem.ShoppingItemRepository.GetByIdAsync(Id);
        }


    }
}
