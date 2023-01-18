namespace ECommerceWebApp.Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly IRepository<T> _repository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthRepository _authRepository;

        public UnitOfWork(DatabaseContext context, IRepository<T> repository, IAccountRepository accountRepository, IAuthRepository authRepository)
        {
            _context = context;
            _repository = repository;
            _accountRepository = accountRepository;
            _authRepository = authRepository;
        }

        public IRepository<T> Repository => _repository;
        public IAccountRepository AccountRepository => _accountRepository;
        public IAuthRepository AuthRepository => _authRepository;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
