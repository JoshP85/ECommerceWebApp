using ECommerceWebApp.Data.Interfaces;
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
                UpdateItemQuantityAndTotalPrice(shoppingItem, Quantity: 1);
                return null;
            }
            else
            {
                return await CreateShoppingItem(product, shoppingCart);
            }
        }

        public void UpdateItemQuantityAndTotalPrice(ShoppingItem shoppingItem, int Quantity)
        {
            shoppingItem.Quantity = Quantity;

            shoppingItem.ShoppingItemTotalPrice = shoppingItem.Product.Price * shoppingItem.Quantity;

            _unitOfWorkShoppingItem.ShoppingItemRepository.Update(shoppingItem);
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


        public void DeleteShoppingItem(ShoppingItem shoppingItem)
        {
            _unitOfWorkShoppingItem.ShoppingItemRepository.Delete(shoppingItem);
        }

        public async Task<decimal> getTotalCostOfCartitems(string shoppingCartId)
        {
            return await _unitOfWorkShoppingItem.ShoppingItemRepository.GetTotalCostOfCartItems(shoppingCartId);
        }

        public void ConvertShoppingItemToOrder(Order order)
        {
            foreach (var shoppingItem in order.OrderItems)
            {
                shoppingItem.Order = order;
                shoppingItem.OrderId = order.OrderId;
                shoppingItem.ShoppingCartId = null;
                shoppingItem.ShoppingCart = null;

                _unitOfWorkShoppingItem.ShoppingItemRepository.Update(shoppingItem);
            }
        }
    }
}

