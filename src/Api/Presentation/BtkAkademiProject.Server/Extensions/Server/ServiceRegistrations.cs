using BtkApiProject.Presentation.ActionFilters;

namespace BtkAkademiProject.Server.Extensions.Server;

public static class ServiceRegistrations
{
    public static void ServerServiceRegistrations(this IServiceCollection services)
    {
        services.AddScoped<ValidationFilterAttribute>();
        services.AddSingleton<LogFilterAttribute>();
    }
}