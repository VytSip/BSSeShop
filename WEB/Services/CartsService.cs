using Database.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.APIConnector;
using WEB.Services.Abstraction;

namespace WEB.Services
{
    public class CartsService : ICartsService
    {
        public async Task<Cart> GetByUserId(string userId)
        {
            using (ApiClient client = new ApiClient())
            {
                var cart = await client.GetAsync<Cart>($"carts/{userId}", $"");
                return cart;
            }
        }

        public async Task<ProductCart> AddToCart(Product product, int quantity, string userId)
        {
            using (ApiClient client = new ApiClient())
            {
                var productCart = new ProductCart { Product = product };
                var cart = await client.PostAsync($"carts", productCart, $"?userId={userId}&quantity={quantity}");
                return cart;
            }
        }

        public async Task<ProductCart> GetCartItem(string cartId, string productId)
        {
            using (ApiClient client = new ApiClient())
            {
                var cartItem = await client.GetAsync<ProductCart>($"productcart", $"?cartId={cartId}&productId={productId}");
                return cartItem;
            }
        }

        public async Task<ProductCart> Update(ProductCart productCart)
        {
            using (ApiClient client = new ApiClient())
            {
                var cartItem = await client.PostAsync($"productcart", productCart, $"");
                return cartItem;
            }
        }

        public async Task<ProductCart> Remove(ProductCart productCart)
        {
            using (ApiClient client = new ApiClient())
            {
                var cartItem = await client.PostAsync($"productcart/remove", productCart, $"");
                return cartItem;
            }
        }
    }
}
