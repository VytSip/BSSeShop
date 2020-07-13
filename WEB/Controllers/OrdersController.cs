using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Data;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using WEB.Services.Abstraction;

namespace WEB.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly ICartsService _cartService;

        public OrdersController(IOrderService orderService, ICartsService cartService)
        {
            _orderService = orderService;
            _cartService = cartService;
        }
        
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _orderService.GetByUserId(userId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> FormOrder()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = await _orderService.FormOrder(userId);

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await _cartService.GetByUserId(userId);
            if (cart == null || userId != cart.UserId)
            {
                return NotFound();
            }

            await _orderService.FormAndCreateOrder(userId);

            return RedirectToAction(nameof(Index));
        }
    }
}
