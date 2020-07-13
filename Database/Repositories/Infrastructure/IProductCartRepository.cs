using Database.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Infrastructure
{
    public interface IProductCartRepository
    {
        Task<ProductCart> Add(ProductCart productCart);
        ProductCart Update(ProductCart productCart);
        Task<ProductCart> Get(string cartId, string productId);
        ProductCart Remove(ProductCart productCart);
    }
}
