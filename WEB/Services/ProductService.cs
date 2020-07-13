using Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.APIConnector;
using WEB.Models;
using WEB.Services.Abstraction;

namespace WEB.Services
{
    public class ProductService : IProductService
    {
        private readonly ICartsService _cartService;

        public ProductService(ICartsService cartService)
        {
            _cartService = cartService;
        }

        public async Task<List<Product>> GetAll()
        {
            using (ApiClient client = new ApiClient())
            {
                var products = await client.GetAsync<List<Product>>($"products", $"");
                return products;
            }
        }

        public async Task<Product> GetById(Guid id)
        {
            using (ApiClient client = new ApiClient())
            {
                var product = await client.GetAsync<Product>($"products/{id}", $"");
                return product;
            }
        }

        public async Task<bool> AddToCart(Product product, ProductViewModel productViewModel, string userId)
        {
            

            return true;
        }
    }
}
