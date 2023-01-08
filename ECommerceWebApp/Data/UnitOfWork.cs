namespace ECommerceWebApp.Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly IRepository<T> _genericRepository;
        private readonly IAccountRepository _registeredUserRepository;

        public UnitOfWork(DatabaseContext context, IRepository<T> genericRepository, IAccountRepository registeredUserRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
            _registeredUserRepository = registeredUserRepository;
        }

        public IRepository<T> GenericRepository => _genericRepository;
        public IAccountRepository RegisteredUserRepository => _registeredUserRepository;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
