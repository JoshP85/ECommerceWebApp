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
            //ShoppingCart shoppingCart = await _unitOfWork.ShoppingCartRepository.GetByIdAsync(shoppingCartId);
            /*            if (shoppingCart == null)
                        {
                            shoppingCart = new ShoppingCart()
                            {
                                CartId = shoppingCartId,
                                TotalPrice = item.TotalPrice,
                                AccountId = null,
                                CartItems = new List<ShoppingItem>()
                            };
                            await _unitOfWork.ShoppingCartRepository.AddAsync(shoppingCart);
                        }*/
            foreach (var cartItem in shoppingCart.CartItems)
            {
                if (cartItem.ProductId == productId)
                {
                    cartItem.Quantity += 1;
                    _shoppingItemUnitOfWork.ShoppingItemRepository.Update(cartItem);
                    await _unitOfWork.SaveChangesAsync();
                    return true;
                }
            }
            ShoppingItem item = await CreateNewShoppingItem(await _productService.GetProductByIdAsync(productId), shoppingCart);
            shoppingCart.CartItems.Add(item);
            await _unitOfWork.SaveChangesAsync();
            return true;
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
        /*        public async Task<ShoppingItem> CreateNewShoppingItem(string productId, decimal productPrice, string shoppingCartId)
                {

                    var quantity = 1;
                    ShoppingItem newItem = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProductId = productId,
                        ShoppingCartId = shoppingCartId,
                        Quantity = quantity,
                        TotalPrice = quantity * productPrice,
                    };
                    await _shoppingItemUnitOfWork.ShoppingItemRepository.AddAsync(newItem);
                    return newItem;
                }*/

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
