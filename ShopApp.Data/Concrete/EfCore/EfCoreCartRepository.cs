using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using ShopApp.Data.Concreate.EfCore;
using ShopApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Data.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart, ShopContext>, ICartRepository
    {
        public void DeleteFromCart(int cartId, int productId)
        {
            using (var context = new ShopContext())
            {
                var cmd = @"delete from CartItems where CartId=@p0 and ProductId=@p1";
                context.Database.ExecuteSqlRaw(cmd,cartId,productId);
            }
        }

        public Cart GetByUserId(string userId)
        {
            using (var context = new ShopContext())
            {
                return context.Cart
                    .Include(x => x.CartItems)
                    .ThenInclude(x => x.Product)
                    .FirstOrDefault(x=>x.UserId == userId);
            }
        }

        public override void Update(Cart entity)
        {
            using (var _db = new ShopContext())
            {
                _db.Cart.Update(entity);
                _db.SaveChanges();
            }
        }
    }
}
