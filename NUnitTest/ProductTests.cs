using API.Services;
using Database.Data;
using Database.Repositories.Infrastructure;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUnitTest
{
    public class ProductTests
    {
        private Mock<IProductRepository> productRepository;
        private ProductService productService;
        private List<Product> products;
        [SetUp]
        public void Setup()
        {
            productRepository = new Mock<IProductRepository>();
            products = new List<Product>();
            products.Add(new Product { Id = Guid.Parse("b03d19a9-f18e-483c-b3a3-97af14829312"), Description = "Ultrasonic", Name = "NewPC", Price = 750 });
            products.Add(new Product { Id = Guid.Parse("a733c141-a4af-451c-8fe7-8f7d3e528351"), Description = "Cheapest", Name = "House", Price = 2000 });
            products.Add(new Product { Id = Guid.Parse("8f286b3d-b33c-43b0-9dec-6ce28d39332b"), Description = "Yummy", Name = "Toothpaste", Price = 5 });
        }

        [Test]
        public async Task TestGetAll()
        {
            //Act
            productRepository.Setup(x => x.GetAll()).Returns(Task.FromResult(products.ToList()));

            //Arrange
            productService = new ProductService(productRepository.Object);
            var productsList = await productService.GetAll();

            //Assert
            Assert.IsTrue(productsList.Count == 3);
        }

        [Test]
        public async Task TestGetById()
        {
            Guid id = Guid.Parse("b03d19a9-f18e-483c-b3a3-97af14829312");
            //Act
            productRepository.Setup(x => x.Get(id)).Returns(Task.FromResult(products.FirstOrDefault(x => x.Id == id)));

            //Arrange
            productService = new ProductService(productRepository.Object);
            var product = await productService.GetById(id);

            //Assert
            Assert.IsTrue(product.Name == "NewPC");
        }
    }
}