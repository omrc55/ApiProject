using BtkApiProject.Presentation.ActionFilters;

namespace BtkAkademiProject.Server.Extensions.Presentation;

public static class ServiceRegistrations
{
    public static void PresentationServiceRegistrations(this IServiceCollection services)
    {
        services.AddScoped<ValidationFilterAttribute>();
        services.AddSingleton<LogFilterAttribute>();
        services.AddScoped<ValidateMediaTypeAttribute>();
    }
}