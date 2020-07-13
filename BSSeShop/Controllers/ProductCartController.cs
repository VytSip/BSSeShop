using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services.Abstraction;
using Database.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public ProductCartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ActionResult<ProductCart>> GetCartItem(string cartId, string productId)
        {
            return await _cartService.GetCartItem(cartId, productId);
        }

        [HttpPost]
        public ActionResult<ProductCart> EditCartItem(ProductCart productCart)
        {
            return _cartService.UpdateCartItem(productCart);
        }

        [HttpPost("{remove}")]
        public ActionResult<ProductCart> Remove(ProductCart productCart)
        {
            return _cartService.RemoveCartItem(productCart);
        }
    }
}
