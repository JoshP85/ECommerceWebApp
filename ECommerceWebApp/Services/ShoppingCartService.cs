using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ShoppingCartService
    {
        private readonly IUnitOfWork<ShoppingCart> _unitOfWork;
        private readonly IUnitOfWork<ShoppingItem> _shoppingItemUnitOfWork;
        private readonly ProductService _productService;

        public ShoppingCartService(IUnitOfWork<ShoppingCart> unitOfWork, IUnitOfWork<ShoppingItem> shoppingItemUnitOfWork, ProductService productService)
        {
            _unitOfWork = unitOfWork;
            _shoppingItemUnitOfWork = shoppingItemUnitOfWork;
            _productService = productService;
        }

        public async Task<bool> AddToCart(string shoppingCartId, /*ShoppingCart shoppingCart,*/ string productId)
        {
            ShoppingCart shoppingCart = GetShoppingCartById(shoppingCartId);

            var cartItem = await _shoppingItemUnitOfWork.ShoppingItemRepository.GetProductAlreadyInCart(productId, shoppingCartId);

            /*            if (_shoppingItemUnitOfWork.ShoppingItemRepository.IsProductAlreadyInCart(productId, shoppingCartId))*/
            if (cartItem != null)
            {
                //ShoppingItem cartItem = await _shoppingItemUnitOfWork.ShoppingItemRepository.GetProductAlreadyInCart(productId, shoppingCartId);
                cartItem.Quantity += 1;
                cartItem.TotalPrice = cartItem.Product.Price * cartItem.Quantity;
                _shoppingItemUnitOfWork.ShoppingItemRepository.Update(cartItem);
                _unitOfWork.ShoppingCartRepository.Update(shoppingCart);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
            {
                ShoppingItem item = await CreateNewShoppingItem(await _productService.GetProductByIdAsync(productId), shoppingCart);
                shoppingCart.CartItems.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
        }

        public async Task<ShoppingItem> CreateNewShoppingItem(Product product, ShoppingCart shoppingCart)
        {
            ShoppingItem newItem = new()
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = product.Id,
                ShoppingCartId = shoppingCart.CartId,
                Quantity = 1,
                TotalPrice = product.Price,
            };
            await _shoppingItemUnitOfWork.ShoppingItemRepository.AddAsync(newItem);
            return newItem;
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

        public decimal GetTotalCostOfCartItems(string cartId)
        {
            return _shoppingItemUnitOfWork.ShoppingItemRepository.GetTotalCostOfCartItems(cartId);
        }
    }
}
