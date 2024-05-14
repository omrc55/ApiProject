using BtkApiProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademiProject.Server.Extensions.Server;

public static class MigrationExtensions
{
    public static void ConfigureMigrations(this IApplicationBuilder app)
    {
        CustomDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CustomDbContext>();

        if (context.Database.GetPendingMigrations().Any())
            context.Database.Migrate();
    }
}
