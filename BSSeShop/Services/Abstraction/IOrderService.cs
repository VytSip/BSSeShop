using Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Abstraction
{
    public interface IOrderService
    {
        Task<List<Order>> GetByUserId(string userId);
        Task<Order> Add(Order order);
        Task<Order> FormOrder(string userId);
        Task<Order> FormAndCreateOrder(string userId);
    }
}
