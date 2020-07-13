using Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.APIConnector;
using WEB.Services.Abstraction;

namespace WEB.Services
{
    public class OrderService : IOrderService
    {
        public async Task<List<Order>> GetByUserId(string userId)
        {
            using (ApiClient client = new ApiClient())
            {
                var orders = await client.GetAsync<List<Order>>($"orders/{userId}", $"");
                return orders;
            }
        }

        public async Task<Order> FormOrder(string userId)
        {
            using (ApiClient client = new ApiClient())
            {
                var order = await client.GetAsync<Order>($"orders/formorder", $"?userId={userId}");
                return order;
            }
        }

        public async Task<Order> FormAndCreateOrder(string userId)
        {
            using (ApiClient client = new ApiClient())
            {
                var order = await client.GetAsync<Order>($"orders/create", $"?userId={userId}");
                return order;
            }
        }
    }
}
