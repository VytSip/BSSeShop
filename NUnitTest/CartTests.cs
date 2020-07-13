using API.Services;
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
    public class CartTests
    {
        private Mock<ICartRepository> cartRepository;
        private Mock<IProductCartRepository> productCartRepository;
        private CartService cartService;
        private List<Cart> carts;
        private List<ProductCart> productCarts;
        [SetUp]
        public void Setup()
        {
            cartRepository = new Mock<ICartRepository>();
            productCartRepository = new Mock<IProductCartRepository>();
            carts = new List<Cart>();
            carts.Add(new Cart { Id = Guid.Parse("b03d19a9-f18e-483c-b3a3-97af14829312"), Active = false, UserId = "b03d19a9-f18e-483c-b3a3-97af14829312" });
            carts.Add(new Cart { Id = Guid.Parse("b03d19a9-f18e-483c-b3a3-97af14829312"), Active = false, UserId = "b03d19a9-f18e-483c-b3a3-97af14829312" });
            carts.Add(new Cart { Id = Guid.Parse("b03d19a9-f18e-483c-b3a3-97af14829312"), Active = true, UserId = "b03d19a9-f18e-483c-b3a3-97af14829312" });
            productCarts = new List<ProductCart>();
            productCarts.Add(new ProductCart { ProductId = Guid.Parse("b03d19a9-f18e-483c-b3a3-97af14829312"), CartId = Guid.Parse("b03d19a9-f18e-483c-b3a3-97af14829312"), Quantity = 3 });
            productCarts.Add(new ProductCart { ProductId = Guid.Parse("b03d19a9-f18e-483c-b3a3-97af14829313"), CartId = Guid.Parse("b03d19a9-f18e-483c-b3a3-97af14829313"), Quantity = 5 });
            productCarts.Add(new ProductCart { ProductId = Guid.Parse("b03d19a9-f18e-483c-b3a3-97af14829314"), CartId = Guid.Parse("b03d19a9-f18e-483c-b3a3-97af14829314"), Quantity = 7 });
        }

        [Test]
        public async Task TestGetByUser()
        {
            string userId = "b03d19a9-f18e-483c-b3a3-97af14829312";
            //Act
            cartRepository.Setup(x => x.GetByUserId(userId)).Returns(carts.FirstOrDefault(x => x.UserId == userId && x.Active));

            //Arrange
            cartService = new CartService(cartRepository.Object, productCartRepository.Object);
            var cart = await cartService.GetByUser(userId);

            //Assert
            Assert.IsTrue(cart.Active == true);
        }

        [Test]
        public async Task TestGetCartItem()
        {
            string id ="b03d19a9-f18e-483c-b3a3-97af14829314";
            //Act
            productCartRepository.Setup(x => x.Get(id, id)).Returns(Task.FromResult(productCarts.FirstOrDefault(x => x.CartId.ToString() == id && x.ProductId.ToString() == id)));

            //Arrange
            cartService = new CartService(cartRepository.Object, productCartRepository.Object);
            var cartItem = await cartService.GetCartItem(id, id);

            //Assert
            Assert.IsTrue(cartItem.Quantity == 7);
        }
    }
}
