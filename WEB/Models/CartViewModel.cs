using Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class CartViewModel
    {
        public Guid Id { get; set; }

        public virtual ICollection<ProductCart> ProductCarts { get; set; }

        public virtual Order Order { get; set; }

        public string UserId { get; set; }

        public decimal TotalPrice { get; set; }

        public static CartViewModel ToViewModel(Cart cart)
        {
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                TotalPrice = cart.ProductCarts.Sum(pc => pc.Quantity * pc.Product.Price),
                ProductCarts = cart.ProductCarts
            };
        }
    }
}
