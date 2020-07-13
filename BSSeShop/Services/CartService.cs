using API.Services.Abstraction;
using Database.Data;
using Database.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        private readonly IProductCartRepository _productCartRepository;

        public CartService(ICartRepository cartRepository, IProductCartRepository productCartRepository)
        {
            _cartRepository = cartRepository;
            _productCartRepository = productCartRepository;
        }

        public async Task<Cart> GetByUser(string userId)
        {
            var cart = _cartRepository.GetByUserId(userId);
            if (cart != null)
            {
                return cart;
            }

            var newCart = await _cartRepository.Add(new Cart { UserId = userId, Active = true });
            return newCart;
        }

        public async Task<ProductCart> AddToCart(ProductCart productCart, int quantity, string userId)
        {
            var cart = await GetByUser(userId);

            var existingProductCart = cart.ProductCarts.FirstOrDefault(x => x.ProductId == productCart.Product.Id);
            if (existingProductCart != null)
            {
                existingProductCart.Quantity += quantity;
                _productCartRepository.Update(existingProductCart);
                return existingProductCart;
            }
            else
            {
                var newProductCart = new ProductCart { ProductId = productCart.Product.Id, CartId = cart.Id, Quantity = quantity };
                await _productCartRepository.Add(newProductCart);
                return newProductCart;
            }
        }

        public async Task<ProductCart> GetCartItem(string cartId, string productId)
        {
            return await _productCartRepository.Get(cartId, productId);
        }

        public ProductCart UpdateCartItem(ProductCart productCart)
        {
            return _productCartRepository.Update(productCart);
        }

        public ProductCart RemoveCartItem(ProductCart productCart)
        {
            return _productCartRepository.Remove(productCart);
        }
    }
}
