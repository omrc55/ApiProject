using BtkApiProject.Presentation;

namespace BtkAkademiProject.Server.Extensions.Server;

public static class ControllerExtensions
{
    public static void ConfigureController(this IServiceCollection services)
    {
        services
            .AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
            })
            .AddXmlDataContractSerializerFormatters()
            .AddCustomCSVFormatter()
            .AddApplicationPart(typeof(AssemblyReference).Assembly);
    }
}