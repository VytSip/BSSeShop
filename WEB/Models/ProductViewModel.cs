using Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public ICollection<ProductCart> ProductCarts { get; set; }

        public static List<ProductViewModel> ToViewModelList(List<Product> products)
        {
            return products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Price = p.Price,
                Description = p.Description,
                Name = p.Name,
                Quantity = 1
            }).ToList();
        }
    }
}
