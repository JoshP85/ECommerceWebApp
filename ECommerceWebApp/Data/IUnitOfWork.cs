namespace ECommerceWebApp.Data
{
    public interface IUnitOfWork<T> where T : class
    {
        IAccountRepository AccountRepository { get; }
        IRepository<T> Repository { get; }




        Task SaveChangesAsync();
    }
}