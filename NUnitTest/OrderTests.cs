using API.Services;
using API.Services.Abstraction;
using Database.Data;
using Database.Repositories.Infrastructure;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest
{
    public class OrderTests
    {
        private Mock<IOrderRepository> orderRepository;
        private OrderService orderService;
        private Mock<ICartService> _cartService;
        private Mock<ICartRepository> _cartRepository;
        private List<Order> orders;
        [SetUp]
        public void Setup()
        {
            orderRepository = new Mock<IOrderRepository>();
            _cartService = new Mock<ICartService>();
            _cartRepository = new Mock<ICartRepository>();

            orders = new List<Order>();
            orders.Add(new Order { Number = 1, Price = 100, User = "a733c141-a4af-451c-8fe7-8f7d3e528351" });
            orders.Add(new Order { Number = 2, Price = 150, User = "a733c141-a4af-451c-8fe7-8f7d3e528351" });
            orders.Add(new Order { Number = 3, Price = 200, User = "a733c141-a4af-451c-8fe7-8f7d3e528351" });
            orders.Add(new Order { Number = 3, Price = 200, User = "b733c141-a4af-451c-8fe7-8f7d3e528352" });
        }

        [Test]
        public async Task TestGetByUserId()
        {
            string userId = "a733c141-a4af-451c-8fe7-8f7d3e528351";
            //Act
            orderRepository.Setup(x => x.GetByUserId(userId)).Returns(Task.FromResult(orders.Where(x => x.User == userId).ToList()));

            //Arrange
            orderService = new OrderService(orderRepository.Object, _cartService.Object, _cartRepository.Object);
            var order = await orderService.GetByUserId(userId);

            //Assert
            Assert.IsTrue(order.Count == 3);
        }
    }
}
