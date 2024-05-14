using BtkApiProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademiProject.Server.Extensions.Persistence;

public static class DbContextConfigurations
{
    public static void CustomDbContextConfiguration(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<CustomDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("mssqlconnection")));
}
