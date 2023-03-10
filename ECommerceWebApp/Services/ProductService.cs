using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork<Product> _unitOfWork;

        public ProductService(IUnitOfWork<Product> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetProductByIdAsync(string productId)
        {
            return await _unitOfWork.ProductRepository.GetByIdAsync(productId);
        }

        public void UpdateProductQuantity(Order order)
        {
            foreach (var item in order.OrderItems)
            {
                item.Product.Quantity -= item.Quantity;
                _unitOfWork.ProductRepository.Update(item.Product);
            }


        }
    }
}
