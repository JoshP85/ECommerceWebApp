using ECommerceWebApp.Data.Interfaces;

namespace ECommerceWebApp.Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly IRepository<T> _repository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public UnitOfWork(DatabaseContext context, IRepository<T> repository, IAccountRepository accountRepository, IAuthRepository authRepository, IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
        {
            _context = context;
            _repository = repository;
            _accountRepository = accountRepository;
            _authRepository = authRepository;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public IRepository<T> Repository => _repository;
        public IAccountRepository AccountRepository => _accountRepository;
        public IAuthRepository AuthRepository => _authRepository;
        public IProductRepository ProductRepository => _productRepository;
        public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
