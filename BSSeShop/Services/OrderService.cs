using API.Services.Abstraction;
using Database.Data;
using Database.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ICartService _cartService;

        private readonly ICartRepository _cartRepository;

        public OrderService(IOrderRepository orderRepository, ICartService cartService, ICartRepository cartRepository)
        {
            _orderRepository = orderRepository;
            _cartService = cartService;
            _cartRepository = cartRepository;
        }

        public async Task<List<Order>> GetByUserId(string userId)
        {
            return await _orderRepository.GetByUserId(userId);
        }

        public async Task<Order> Add(Order order)
        {
            return await _orderRepository.Add(order);
        }

        public async Task<Order> FormOrder(string userId)
        {
            var cart = await _cartService.GetByUser(userId);

            var lastOrderNumber = _orderRepository.GetLastOrderNumber();

            var order = new Order { Cart = cart, Number = lastOrderNumber + 1, User = userId, Price = cart.ProductCarts.Sum(pc => pc.Product.Price * pc.Quantity) };

            return order;
        }

        public async Task<Order> FormAndCreateOrder(string userId)
        {
            var cart = await _cartService.GetByUser(userId);

            var lastOrderNumber = _orderRepository.GetLastOrderNumber();

            var order = new Order { Cart = cart, Number = lastOrderNumber + 1, User = userId, Price = cart.ProductCarts.Sum(pc => pc.Product.Price * pc.Quantity) };

            await _orderRepository.Add(order);

            cart.Active = false;

            await _cartRepository.Update(cart);

            return order;
        }
    }
}
