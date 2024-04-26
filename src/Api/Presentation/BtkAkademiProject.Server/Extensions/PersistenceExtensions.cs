using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Application.Interfaces.Repositories.Write;
using BtkApiProject.Persistence.Contexts;
using BtkApiProject.Persistence.Repositories.Read;
using BtkApiProject.Persistence.Repositories.Write;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademiProject.Server.Extensions;

public static class PersistenceExtensions
{
    public static void CustomDbContextConfiguration(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<CustomDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("mssqlconnection")));

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();

        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IProductDetailWriteRepository, ProductDetailWriteRepository>();
    }
}
