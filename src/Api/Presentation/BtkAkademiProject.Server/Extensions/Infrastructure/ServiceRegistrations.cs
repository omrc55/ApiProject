using BtkApiProject.Application.Interfaces.Services;
using BtkApiProject.Infrastructure.Services;

namespace BtkAkademiProject.Server.Extensions.Infrastructure;

public static class ServiceRegistrations
{
    public static void InfrastructureServiceRegistrations(this IServiceCollection services)
    {
        services.AddTransient<ILoggerService, LoggerService>();
    }
}