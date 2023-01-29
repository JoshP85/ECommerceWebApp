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

        public bool RemoveShoppingItem(ShoppingItemDTO shoppingItem)
        {
            if (shoppingItem.QuantityInCart <= 1)
            {
                _unitOfWorkShoppingItem.ShoppingItemRepository.Delete(shoppingItem.ShoppingItem);
                return true;
            }

            shoppingItem.ShoppingItem.Quantity -= 1;
            shoppingItem.ShoppingItem.ShoppingItemTotalPrice -= shoppingItem.ProductPrice;
            _unitOfWorkShoppingItem.ShoppingItemRepository.Update(shoppingItem.ShoppingItem);

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
