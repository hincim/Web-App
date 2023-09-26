using ShopApp.Entity;
using System.Collections.Generic;

namespace ShopApp.Data.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetOrders(string userId);

    }
}
