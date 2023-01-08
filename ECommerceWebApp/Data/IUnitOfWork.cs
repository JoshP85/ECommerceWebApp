namespace ECommerceWebApp.Data
{
    public interface IUnitOfWork<T> where T : class
    {
        IAccountRepository AccountRepository { get; }

        Task SaveChangesAsync();
    }
}