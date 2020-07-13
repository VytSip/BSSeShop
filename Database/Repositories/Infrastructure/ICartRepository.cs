using Database.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Repositories.Infrastructure
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Cart GetByUserId(string userId);
    }
}
