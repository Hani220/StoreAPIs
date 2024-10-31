using Store.Repository.Interfaces;
using Store.Repository.UnitOfWork;
using Store.Service.Services.Products.Dtos;
using Store.Service.Services.Products;
using Store.Service.Services;

namespace Store.Web.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection ApplicationsServices (this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(typeof(ProductProfile));

            //builder.Services.Configure<CustomException>(options => 
            //options.
            //);

            return services;
        }

    }
}
