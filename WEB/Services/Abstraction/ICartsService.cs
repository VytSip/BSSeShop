using Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Services.Abstraction
{
    public interface ICartsService
    {
        Task<Cart> GetByUserId(string userId);
        Task<ProductCart> AddToCart(Product product, int quantity, string userId);
        Task<ProductCart> GetCartItem(string cartId, string productId);
        Task<ProductCart> Update(ProductCart productCart);
        Task<ProductCart> Remove(ProductCart productCart);
    }
}
