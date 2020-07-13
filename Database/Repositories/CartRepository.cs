using Database.Data;
using Database.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Repositories
{
    public class CartRepository : BaseRepository<Cart, EShopContext>, ICartRepository
    {
        private readonly EShopContext _context;
        public CartRepository(EShopContext context) : base(context)
        {
            _context = context;
        }

        public Cart GetByUserId(string userId)
        {
            return _context.Carts.Include("ProductCarts.Product").FirstOrDefault(x => x.UserId == userId && x.Active);
        }
    }
}
