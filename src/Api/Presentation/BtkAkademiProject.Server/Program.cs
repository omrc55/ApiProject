using BtkAkademiProject.Server.Extensions;
using BtkApiProject.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddApplicationPart(typeof(AssemblyReference).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Extensions
builder.Services.CustomDbContextConfiguration(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddApplicationSettings();
builder.Services.ConfigureHttpLogging();

builder.Host.ConfigureSerilog(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseAuthorization();

// Extensions
app.ConfigureMigrations();

app.MapControllers();

app.Run();