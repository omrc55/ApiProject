using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Application.Interfaces.Repositories.Write;
using BtkApiProject.Application.Interfaces.Services;
using BtkApiProject.Common.DTOs.Products;
using BtkApiProject.Persistence.Repositories.Read;
using BtkApiProject.Persistence.Repositories.Write;
using BtkApiProject.Persistence.Services;

namespace BtkAkademiProject.Server.Extensions.Persistence;

public static class ServiceRegistrations
{
    public static void PersistenceServiceRegistrations(this IServiceCollection services)
    {
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();

        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IProductDetailWriteRepository, ProductDetailWriteRepository>();

        services.AddScoped<IDataShaper<ProductResponseDTO>, DataShaper<ProductResponseDTO>>();

        services.AddScoped<IProductLinks, ProductLinks>();
    }
}
