using Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Abstraction
{
    public interface ICartService
    {
        Task<Cart> GetByUser(string id);
        Task<ProductCart> AddToCart(ProductCart productCart, int quantity, string userId);
        Task<ProductCart> GetCartItem(string cartId, string productId);
        ProductCart UpdateCartItem(ProductCart productCart);
        ProductCart RemoveCartItem(ProductCart productCart);
    }
}
