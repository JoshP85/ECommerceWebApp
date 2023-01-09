namespace ECommerceWebApp.Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly IRepository<T> _repository;
        private readonly IAccountRepository _accountRepository;

        public UnitOfWork(DatabaseContext context, IRepository<T> repository, IAccountRepository accountRepository)
        {
            _context = context;
            _repository = repository;
            _accountRepository = accountRepository;
        }

        public IRepository<T> Repository => _repository;
        public IAccountRepository AccountRepository => _accountRepository;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
