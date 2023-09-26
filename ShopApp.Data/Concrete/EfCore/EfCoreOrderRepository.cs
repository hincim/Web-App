using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using ShopApp.Data.Concreate.EfCore;
using ShopApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Data.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order, ShopContext>, IOrderRepository
    {
        public List<Order> GetOrders(string userId)
        {
            using (var context = new ShopContext())
            {
                var orders = context.Orders
                    .Include(o => o.OrderItems)
                    .ThenInclude(o => o.Product)
                    .AsQueryable();
                if (string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(o => o.UserId == userId);
                }
                return orders.ToList();
            }
        }
    }
}
