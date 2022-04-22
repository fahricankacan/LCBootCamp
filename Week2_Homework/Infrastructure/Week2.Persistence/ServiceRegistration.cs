using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.CategoryRepository;
using Week2.Application.Repositories.DiscountRepository;
using Week2.Application.Repositories.InventoryRepository;
using Week2.Application.Repositories.ProductRepository;
using Week2.Persistence.Contexts;
using Week2.Persistence.Repositories.CategoryRepository;
using Week2.Persistence.Repositories.DiscountRepository;
using Week2.Persistence.Repositories.InventoryRepository;
using Week2.Persistence.Repositories.ProductRepository;

namespace Week2.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<Week2DbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));

            //product
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            //category
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            //Discount
            services.AddScoped<IDiscountReadRepository, DiscountReadRepository>();
            services.AddScoped<IDiscountWriteRepository, DiscountWriteRepository>();
            //Inventory
            services.AddScoped<IInventoryReadRepository, InventoryReadRepository>();
            services.AddScoped<IInventoryWriteRepository, InventoryWriteRepository>();
            



        }
    }
}
