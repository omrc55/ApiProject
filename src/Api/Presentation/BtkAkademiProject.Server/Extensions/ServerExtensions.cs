using BtkApiProject.Persistence.Contexts;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;

namespace BtkAkademiProject.Server.Extensions;

public static class ServerExtensions
{
    public static void ConfigureMigrations(this IApplicationBuilder app)
    {
        CustomDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CustomDbContext>();

        if (context.Database.GetPendingMigrations().Any())
            context.Database.Migrate();
    }

    public static void ConfigureHttpLogging(this IServiceCollection services)
    {
        services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.All;
            logging.RequestHeaders.Add("sec-ch-ua");
            logging.ResponseHeaders.Add("BtkAkademiProjectLog");
            logging.MediaTypeOptions.AddText("application/javascript");
            logging.RequestBodyLogLimit = 4096;
            logging.ResponseBodyLogLimit = 4096;
            logging.CombineLogs = true;
        });
    }

    public static void ConfigureSerilog(this ConfigureHostBuilder host, IConfiguration configuration)
    {
        Logger log = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        host.UseSerilog(log);
    }
}
