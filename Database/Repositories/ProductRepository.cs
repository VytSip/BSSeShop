using Database.Data;
using Database.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Repositories
{
    public class ProductRepository : BaseRepository<Product, EShopContext>, IProductRepository
    {
        public ProductRepository(EShopContext context) : base(context)
        {
        }
    }
}
