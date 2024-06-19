using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace BtkAkademiProject.Server.Extensions.Server;

public static class MediaTypeExtensions
{
    public static void ConfigureMediaTypes(this IServiceCollection services)
    {
        services.Configure<MvcOptions>(config =>
        {
            var jsonOutputFormatter = config.OutputFormatters.OfType<SystemTextJsonOutputFormatter>().FirstOrDefault();
            jsonOutputFormatter?.SupportedMediaTypes.Add("application/vnd.reysadijital.hateoas+json");

            var xmlOutputFormatter = config.OutputFormatters.OfType<XmlDataContractSerializerOutputFormatter>().FirstOrDefault();
            xmlOutputFormatter?.SupportedMediaTypes.Add("application/vnd.reysadijital.hateoas+xml");
        });
    }
}