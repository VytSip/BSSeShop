using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Data;
using API.Services.Abstraction;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductCartController>> AddToCart(ProductCart productCart, string userId, int quantity)
        {
            var createdProductCart = await _cartService.AddToCart(productCart, quantity, userId);
            return Ok(createdProductCart);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Cart>> GetCaret(string userId)
        {
            return await _cartService.GetByUser(userId);
        }
    }
}
