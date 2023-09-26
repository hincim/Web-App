using ShopApp.Entity;

namespace ShopApp.Data.Abstract
{
    public interface ICartRepository: IRepository<Cart>
    {
        void ClearCart(int cartId);
        void DeleteFromCart(int cartId, int productId);
        Cart GetByUserId(string userId);

    }
}
