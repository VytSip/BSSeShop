using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Data;
using API.Services.Abstraction;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder(string id)
        {
            return await _orderService.GetByUserId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _orderService.Add(order);

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // GET: api/Orders
        [HttpGet]
        [Route("formorder")]
        public async Task<ActionResult<Order>> FormOrder(string userId)
        {
            return await _orderService.FormOrder(userId);
        }

        // GET: api/Orders
        [HttpGet]
        [Route("create")]
        public async Task<ActionResult<Order>> FormAndCreateOrder(string userId)
        {
            return await _orderService.FormAndCreateOrder(userId);
        }
    }
}
