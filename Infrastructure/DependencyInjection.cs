using Domain.Products;
using Domain.Sales;
using Domain.Tables;
using Infrastructure.Products;
using Infrastructure.Sales;
using Infrastructure.Tables;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
        }
    }
}
