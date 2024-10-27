using Application.Categories;
using Application.Products;
using Application.Sales;
using Application.Tables;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
