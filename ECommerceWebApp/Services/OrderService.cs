using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.DTOs;
using ECommerceWebApp.Models;
using ECommerceWebApp.ViewModels;

namespace ECommerceWebApp.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork<Order> _unitOfWork;
        private readonly ShoppingItemService _shoppingItemService;
        private readonly AccountService _accountService;
        private readonly ProductService _productService;
        private readonly ShoppingCartService _shoppingCartService;
        public OrderService(IUnitOfWork<Order> unitOfWork, ShoppingItemService shoppingItemService, AccountService accountService, ProductService productService, ShoppingCartService shoppingCartService)
        {
            _unitOfWork = unitOfWork;
            _shoppingItemService = shoppingItemService;
            _accountService = accountService;
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        public async Task CreateOrder(OrderDTO newOrder)
        {
            newOrder.ShoppingCart = await _shoppingCartService.GetShoppingCartById(newOrder.ShoppingCartId);

            Address address = new()
            {
                AddressId = Guid.NewGuid().ToString(),
                AddressLine1 = newOrder.AddressLine1,
                AddressLine2 = newOrder.AddressLine2,
                City = newOrder.City,
                State = newOrder.State,
                PostalCode = newOrder.PostalCode,
                Country = newOrder.Country,
            };

            Order order = new()
            {
                Account = await _accountService.GetAccountById(newOrder.AccountId),
                OrderId = Guid.NewGuid().ToString(),
                AccountId = newOrder.AccountId,
                ShippingAddress = address,
                AddressId = address.AddressId,
                OrderItems = newOrder.ShoppingCart.CartItems,
                OrderDate = DateTime.Now.ToString(),
                TotalPrice = newOrder.ShoppingCart.ShoppingCartTotalPrice
            };

            ConvertShoppingItemToOrder(order);

            await _accountService.UpdateOrderHistory(order);

            _productService.UpdateProductQuantity(order);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllByAccountId(string accountId)
        {
            return await _unitOfWork.OrderRepository.GetAllByAccountId(accountId);
        }

        public void ConvertShoppingItemToOrder(Order order)
        {
            _shoppingItemService.ConvertShoppingItemToOrder(order);
        }

        public async Task<OrderViewModel> GetOrderSummery(string shoppingCartId, string accountId)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartById(shoppingCartId);

            foreach (var item in shoppingCart.CartItems)
            {
                item.OrderPrice = shoppingCart.CartItems
                    .Where(ci => ci.ProductId == item.ProductId)
                    .Select(p => p.Product.Price).FirstOrDefault();
            }
            _unitOfWork.ShoppingCartRepository.Update(shoppingCart);
            await _unitOfWork.SaveChangesAsync();

            OrderViewModel ovm = new()
            {
                ShoppingCart = shoppingCart,
                Account = await _accountService.GetAccountById(accountId),
            };
            return ovm;
        }
    }
}
