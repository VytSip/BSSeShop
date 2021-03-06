﻿using Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Services.Abstraction
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(Guid id);
    }
}
