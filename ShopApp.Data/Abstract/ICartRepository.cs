using ShopApp.Entity;

namespace ShopApp.Data.Abstract
{
    public interface ICartRepository: IRepository<Cart>
    {
        void DeleteFromCart(int cartId, int productId);
        Cart GetByUserId(string userId);

    }
}
