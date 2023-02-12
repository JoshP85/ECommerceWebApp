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
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IShoppingItemRepository _shoppingItemRepository;

        public UnitOfWork(DatabaseContext context, IRepository<T> repository,
            IAccountRepository accountRepository, IAuthRepository authRepository,
            IProductRepository productRepository, IProductCategoryRepository productCategoryRepository,
            IShoppingCartRepository shoppingCartRepository, IShoppingItemRepository shoppingItemRepository)
        {
            _context = context;
            _repository = repository;
            _accountRepository = accountRepository;
            _authRepository = authRepository;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _shoppingItemRepository = shoppingItemRepository;
        }

        public IRepository<T> Repository => _repository;
        public IAccountRepository AccountRepository => _accountRepository;
        public IAuthRepository AuthRepository => _authRepository;
        public IProductRepository ProductRepository => _productRepository;
        public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository;
        public IShoppingCartRepository ShoppingCartRepository => _shoppingCartRepository;
        public IShoppingItemRepository ShoppingItemRepository => _shoppingItemRepository;



        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
