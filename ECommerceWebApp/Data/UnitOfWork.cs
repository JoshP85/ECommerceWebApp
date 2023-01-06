namespace ECommerceWebApp.Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly IGenericRepository<T> _genericRepository;
        private readonly IRegisteredUserRepository _registeredUserRepository;

        public UnitOfWork(DatabaseContext context, IGenericRepository<T> genericRepository, IRegisteredUserRepository registeredUserRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
            _registeredUserRepository = registeredUserRepository;
        }

        public IGenericRepository<T> GenericRepository => _genericRepository;
        public IRegisteredUserRepository RegisteredUserRepository => _registeredUserRepository;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
