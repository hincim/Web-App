using ShopApp.Business.Abstract;
using ShopApp.Data.Abstract;
using ShopApp.Entity;

namespace ShopApp.Business.Concrete
{
    public class CartManager : ICartService
    {
        //private ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CartManager(/*ICartRepository cartRepository,*/ IUnitOfWork unitOfWork)
        {
            //_cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddToCart(string userId, int productId, int quantity)
        {
            var cart = GetCartByUserId(userId);

            if (cart != null)
            {
                // eklenmek istenen ürün sepette var mı? (güncelleme)
                // eklenmek istenen ürün sepette var ve yeni kayıt oluştur. (kayıt ekleme)

                var index = cart.CartItems.FindIndex(i => i.ProductId == productId);
                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }

                //_cartRepository.Update(cart);
                _unitOfWork.Carts.Update(cart);
            }
        }

        public void ClearCart(int cartId)
        {
            //_cartRepository.ClearCart(cartId);
            _unitOfWork.Carts.ClearCart(cartId);
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if(cart != null)
            {
                //_cartRepository.DeleteFromCart(cart.Id,productId);
                _unitOfWork.Carts.DeleteFromCart(cart.Id, cart.Id);
            }
        }

        public Cart GetCartByUserId(string userId)
        {
            //return _cartRepository.GetByUserId(userId);
            return _unitOfWork.Carts.GetByUserId(userId);
        }

        public void InitializeCard(string userId)
        {
            _unitOfWork.Carts.Create(new Cart()
            {
                UserId = userId
            });
            //_cartRepository.Create(new Cart()
            //{
            //    UserId = userId,
            //});
        }
    }
}
