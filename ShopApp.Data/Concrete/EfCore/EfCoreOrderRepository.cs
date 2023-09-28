using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using ShopApp.Data.Concreate.EfCore;
using ShopApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Data.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        private ShopContext context;

        public EfCoreOrderRepository(ShopContext _context): base(_context) 
        {
            context = _context;
        }
        private ShopContext ShopContext { get { return context as ShopContext; } }
       
        public List<Order> GetOrders(string userId)
        {
            var orders = ShopContext.Orders
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
