namespace ECommerceWebApp.Data
{
    public interface IUnitOfWork<T> where T : class
    {
        IAccountRepository RegisteredUserRepository { get; }

        Task SaveChangesAsync();
    }
}