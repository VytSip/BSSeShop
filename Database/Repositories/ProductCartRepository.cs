using Database.Data;
using Database.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class ProductCartRepository : IProductCartRepository
    {
        private readonly EShopContext _context;
        public ProductCartRepository(EShopContext context)
        {
            _context = context;
        }

        public async Task<ProductCart> Add(ProductCart productCart)
        {
            _context.ProductCarts.Add(productCart);

            _context.SaveChanges();
            return productCart;
        }

        public ProductCart Update(ProductCart productCart)
        {
            _context.Entry(productCart).State = EntityState.Modified;
            _context.SaveChanges();
            return productCart;
        }

        public async Task<ProductCart> Get(string cartId, string productId)
        {
            return await _context.ProductCarts.FirstOrDefaultAsync(pc => pc.CartId.ToString() == cartId && pc.ProductId.ToString() == productId);
        }

        public ProductCart Remove(ProductCart productCart)
        {
            _context.Entry(productCart).State = EntityState.Deleted;
            _context.SaveChanges();
            return productCart;
        }
    }
}
