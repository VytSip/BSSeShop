using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Data;
using WEB.APIConnector;
using System.Security.Claims;
using WEB.Models;
using WEB.Services.Abstraction;

namespace WEB.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartsService _cartService;

        public CartsController(ICartsService cartService)
        {
            _cartService = cartService;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cart = await _cartService.GetByUserId(userId);

            return View(CartViewModel.ToViewModel(cart));
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(string cartId, string productId)
        {
            if (String.IsNullOrEmpty(cartId) || String.IsNullOrEmpty(productId))
            {
                return NotFound();
            }

            var cartItem = await _cartService.GetCartItem(cartId, productId);
            if (cartItem == null)
            {
                return NotFound();
            }
            return View(cartItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("CartId,ProductId,Quantity")] ProductCart productCart)
        {
            if (ModelState.IsValid)
            {
                await _cartService.Update(productCart);
                return RedirectToAction(nameof(Index));
            }
            return View(productCart);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string cartId, string productId)
        {
            var productCart = await _cartService.GetCartItem(cartId, productId);
            await _cartService.Remove(productCart);
            return RedirectToAction(nameof(Index));
        }
    }
}
