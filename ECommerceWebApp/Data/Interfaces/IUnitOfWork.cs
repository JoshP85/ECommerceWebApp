namespace ECommerceWebApp.Data.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IAccountRepository AccountRepository { get; }
        IAuthRepository AuthRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
        IRepository<T> Repository { get; }




        Task SaveChangesAsync();
    }
}