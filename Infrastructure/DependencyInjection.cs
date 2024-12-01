using Domain.Categories;
using Domain.Entities.Products;
using Domain.Measures;
using Domain.Sales;
using Domain.Tables;
using Infrastructure.Categories;
using Infrastructure.Measures;
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
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMeasureRepository, MeasureRepository>();
        }
    }
}
