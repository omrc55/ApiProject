using BtkApiProject.Application.AutoMapper;
using BtkApiProject.Application.Extensions;

namespace BtkAkademiProject.Server.Extensions;

public static class ApplicationExtensions
{
    public static void AddApplicationSettings(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(VariableExtension).Assembly));
        services.AddAutoMapper(typeof(MapperProfile).Assembly);
    }
}