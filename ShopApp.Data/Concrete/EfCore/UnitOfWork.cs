using ShopApp.Data.Abstract;
using ShopApp.Data.Concreate.EfCore;

namespace ShopApp.Data.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _context;
        public UnitOfWork(ShopContext context)
        {
            _context = context;
        }
        private EfCoreCartRepository _cartRepository;
        private EfCoreCategoryRepository _categoryRepository;
        private EfCoreOrderRepository _orderRepository;
        private EfCoreProductRepository _productRepository;

        public ICartRepository Carts => _cartRepository = _cartRepository ?? new EfCoreCartRepository(_context);
        public ICategoryRepository Category => _categoryRepository = _categoryRepository ?? new EfCoreCategoryRepository(_context);
        public IOrderRepository Order => _orderRepository = _orderRepository ?? new EfCoreOrderRepository(_context);
        public IProductRepository Products => _productRepository = _productRepository ?? new EfCoreProductRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
