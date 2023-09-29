using ShopApp.Business.Abstract;
using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System.Collections.Generic;

namespace ShopApp.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        //private IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OrderManager(/*IOrderRepository orderRepository, */IUnitOfWork unitOfWork)
        {
            //_orderRepository = orderRepository;
            _unitOfWork = unitOfWork;

        }
        public void Create(Order entity)
        {
            //_orderRepository.Create(entity);
            _unitOfWork.Order.Create(entity);
            _unitOfWork.Save();
        }

        public List<Order> GetOrders(string userId)
        {
            //return _orderRepository.GetOrders(userId);
            return _unitOfWork.Order.GetOrders(userId);
        }
    }
}
