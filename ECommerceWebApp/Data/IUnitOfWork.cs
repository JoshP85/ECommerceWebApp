namespace ECommerceWebApp.Data
{
    public interface IUnitOfWork<T> where T : class
    {
        IAccountRepository AccountRepository { get; }
        IAuthRepository AuthRepository { get; }
        IRepository<T> Repository { get; }




        Task SaveChangesAsync();
    }
}