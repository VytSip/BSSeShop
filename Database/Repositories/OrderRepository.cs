using Database.Data;
using Database.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class OrderRepository : BaseRepository<Order, EShopContext>, IOrderRepository
    {
        private readonly EShopContext _context;

        public OrderRepository(EShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetByUserId(string userId)
        {
            return await _context.Orders.Include("Cart.ProductCarts.Product").Where(o => o.User == userId).ToListAsync();
        }

        public int GetLastOrderNumber()
        {
            var lastOrderNumber = _context.Orders.OrderByDescending(x => x.Number).FirstOrDefault()?.Number;

            if (lastOrderNumber == null)
            {
                lastOrderNumber = 0;
            }
            return lastOrderNumber.Value;
        }
    }
}
