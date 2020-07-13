using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Services;
using WEB.Services.Abstraction;

namespace WEB.Configuration
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureDependencyServices(this IServiceCollection services)
        {
            services.AddScoped<ICartsService, CartsService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
