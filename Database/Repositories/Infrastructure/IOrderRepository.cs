using Database.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Infrastructure
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetByUserId(string userId);
        int GetLastOrderNumber();
    }
}
