using BtkAkademiProject.Server.Extensions.Application;
using BtkAkademiProject.Server.Extensions.Infrastructure;
using BtkAkademiProject.Server.Extensions.Persistence;
using BtkAkademiProject.Server.Extensions.Server;
using BtkApiProject.Application.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Extensions
builder.Services.ConfigureController();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Extensions
builder.Services.CustomDbContextConfiguration(builder.Configuration);
builder.Services.ApplicationServiceRegistrations();
builder.Services.PersistenceServiceRegistrations();
builder.Services.InfrastructureServiceRegistrations();
builder.Services.ConfigureHttpLogging();

builder.Host.ConfigureSerilog(builder.Configuration);

var app = builder.Build();

// Extensions
var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHsts();
app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseAuthorization();

// Extensions
app.ConfigureMigrations();

app.MapControllers();

app.Run();