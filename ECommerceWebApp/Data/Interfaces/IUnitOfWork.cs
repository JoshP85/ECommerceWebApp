namespace ECommerceWebApp.Data.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IAccountRepository AccountRepository { get; }
        IAuthRepository AuthRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }
        IShoppingItemRepository ShoppingItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        IRepository<T> Repository { get; }

        Task SaveChangesAsync();

        void Dispose();
    }
}