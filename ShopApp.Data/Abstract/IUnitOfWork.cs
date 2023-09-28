using System;

namespace ShopApp.Data.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        ICartRepository Carts { get; }
        ICategoryRepository Category { get; }
        IOrderRepository Order { get; }
        IProductRepository Products { get; }
        void Save();
    }
}
