using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ShoppingCartService
    {
        private readonly IUnitOfWork<ShoppingCart> _unitOfWork;
        private readonly IUnitOfWork<ShoppingItem> _shoppingItemUnitOfWork;

        public ShoppingCartService(IUnitOfWork<ShoppingCart> unitOfWork, IUnitOfWork<ShoppingItem> shoppingItemUnitOfWork)
        {
            _unitOfWork = unitOfWork;
            _shoppingItemUnitOfWork = shoppingItemUnitOfWork;
        }

        public async Task<bool> AddToCart(string shoppingCartId, ShoppingItem item)
        {
            ShoppingCart shoppingCart = await _unitOfWork.ShoppingCartRepository.GetByIdAsync(shoppingCartId);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart()
                {
                    CartId = shoppingCartId,
                    TotalPrice = item.TotalPrice,
                    AccountId = null,
                    CartItems = new List<ShoppingItem>()
                };
                await _unitOfWork.ShoppingCartRepository.AddAsync(shoppingCart);
            }
            shoppingCart.CartItems.Add(item);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ShoppingItem> CreateNewShoppingItem(string producId, decimal productPrice, string shoppingCartId)
        {

            var quantity = 1;
            ShoppingItem newItem = new()
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = producId,
                ShoppingCartId = shoppingCartId,
                Quantity = quantity,
                TotalPrice = quantity * productPrice,
            };
            await _shoppingItemUnitOfWork.ShoppingItemRepository.AddAsync(newItem);
            return newItem;
        }

        public ShoppingCart CreateShoppingCart()
        {
            return new ShoppingCart()
            {
                CartId = Guid.NewGuid().ToString(),
                TotalPrice = 0,
                AccountId = null,
            };
        }

        public void CreateNewAccountShoppingCart(Account newUserAccount)
        {
            ShoppingCart cart = new()
            {
                CartId = newUserAccount.ShoppingCartId,
                TotalPrice = 0,
                Account = newUserAccount,
                AccountId = newUserAccount.Id
            };
            _unitOfWork.ShoppingCartRepository.AddAsync(cart);

        }

        public ShoppingCart GetShoppingCartById(string shoppingCartId)
        {
            return _unitOfWork.ShoppingCartRepository.GetShoppingCartById(shoppingCartId);
        }
    }
}
