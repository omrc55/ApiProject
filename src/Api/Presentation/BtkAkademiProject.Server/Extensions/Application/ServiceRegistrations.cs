using BtkApiProject.Application.AutoMapper;
using BtkApiProject.Application.Extensions;

namespace BtkAkademiProject.Server.Extensions.Application;

public static class ServiceRegistrations
{
    public static void ApplicationServiceRegistrations(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(VariableExtension).Assembly));
        services.AddAutoMapper(typeof(MapperProfile).Assembly);
    }
}
