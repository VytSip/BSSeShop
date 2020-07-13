using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace UnitTest.API
{
    [TestClass]
    public class ProductsTests
    {
        public ProductsTests()
        {
            var server = new TestServer()
        }

        [Theory]
        [InlineData("GET")]
        public void GetProductsTest(string method)
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
