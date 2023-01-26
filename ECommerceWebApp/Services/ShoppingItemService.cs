﻿using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ShoppingItemService
    {
        private readonly IUnitOfWork<ShoppingItem> _unitOfWork;

        public ShoppingItemService(IUnitOfWork<ShoppingItem> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShoppingItem> GetShoppingItemInCart(string productId, string shoppingCartId) =>
            await _unitOfWork.ShoppingItemRepository.GetShoppingItemInCart(productId, shoppingCartId);

        public async Task<ShoppingItem> UpdateShoppingItem(ShoppingItem cartItem)
        {
            cartItem.Quantity += 1;
            cartItem.TotalPrice = cartItem.Product.Price * cartItem.Quantity;

            _unitOfWork.ShoppingItemRepository.Update(cartItem);

            await _unitOfWork.SaveChangesAsync();

            return null;
        }

        public async Task<ShoppingItem> CreateShoppingItem(Product product, ShoppingCart shoppingCart)
        {
            ShoppingItem newItem = new()
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = product.Id,
                ShoppingCartId = shoppingCart.CartId,
                Quantity = 1,
                TotalPrice = product.Price,
            };

            await _unitOfWork.ShoppingItemRepository.AddAsync(newItem);

            return newItem;
        }
    }
}