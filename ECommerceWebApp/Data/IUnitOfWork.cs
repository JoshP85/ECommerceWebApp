namespace ECommerceWebApp.Data
{
    public interface IUnitOfWork<T> where T : class
    {
        IRegisteredUserRepository RegisteredUserRepository { get; }

        Task SaveChangesAsync();
    }
}