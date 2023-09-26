using ShopApp.Entity;
using System.Collections.Generic;

namespace ShopApp.Business.Abstract
{
    public interface IOrderService
    {
        void Create(Order entity);
        List<Order> GetOrders(string userId);
    }
}
