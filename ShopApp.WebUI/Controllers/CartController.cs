using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Identity;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.WebUI.Controllers
{
    [Authorize]
    public class CartController: Controller
    {
        private ICartService _cartService;
        private IOrderService _orderService;
        private UserManager<User> _userManager;
        public CartController(ICartService cartService, UserManager<User> userManager, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View(new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(cartItem => new CartItemModel
                {
                    CartItemId = cartItem.Id,
                    ImageUrl = cartItem.Product.ImageUrl,
                    Name = cartItem.Product.Name,
                    Price = (double)cartItem.Product.Price,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                }).ToList()
            });
        }
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            _cartService.AddToCart(_userManager.GetUserId(User), productId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteFromCart(int productId) 
        {
            _cartService.DeleteFromCart(_userManager.GetUserId(User), productId);
            return RedirectToAction("Index");
        }

        public IActionResult CheckOut()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));

            var orderModel = new OrderModel()
            {
                CartModel = new CartModel()
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(cartItem => new CartItemModel
                    {
                        CartItemId = cartItem.Id,
                        ImageUrl = cartItem.Product.ImageUrl,
                        Name = cartItem.Product.Name,
                        Price = (double)cartItem.Product.Price,
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                    }).ToList()
                }
            };

            return View(orderModel);
        }
        [HttpPost]
        public IActionResult Checkout(OrderModel model) 
        {
            if (ModelState.IsValid)
            {
                // credit card integration

                //_orderService.Create(order);

                return View("Success");

            }
            return View(model);
        }

        public IActionResult GetOrders()
        {
            var orders = _orderService.GetOrders(_userManager.GetUserId(User));

            var orderListModel = new List<OrderListModel>();
            OrderListModel orderModel;

            foreach (var order in orders)
            {
                orderModel = new OrderListModel();

                orderModel.OrderId = order.Id;
                orderModel.Address = order.Address;
                orderModel.OrderNumber = order.OrderNumber;
                orderModel.OrderDate = order.OrderDate;
                orderModel.Note = order.Note;
                orderModel.Phone = order.Phone;
                orderModel.FirstName = order.FirstName;
                orderModel.LastName = order.LastName;
                orderModel.Email = order.Email;
                orderModel.Address = order.Address;
                orderModel.City = order.City;
                orderModel.OrderState = order.OrderState;
                orderModel.PaymentType = order.PaymentType;

                orderModel.OrderItems = order.OrderItems.Select(i=>new OrderItemModel()
                {
                    OrderItemId = i.Id,
                    Name = i.Product.Name,
                    Price = (double)i.Price,
                    Quantity = i.Quantity,
                    ImageUrl = i.Product.ImageUrl
                }).ToList();

                orderListModel.Add(orderModel);
            }
           
            return View("Orders", orderListModel);
        }
    }
}
