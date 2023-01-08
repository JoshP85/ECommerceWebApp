namespace ECommerceWebApp.Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly IRepository<T> _genericRepository;
        private readonly IAccountRepository _accountRepository;

        public UnitOfWork(DatabaseContext context, IRepository<T> genericRepository, IAccountRepository accountRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
            _accountRepository = accountRepository;
        }

        public IRepository<T> GenericRepository => _genericRepository;
        public IAccountRepository AccountRepository => _accountRepository;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
