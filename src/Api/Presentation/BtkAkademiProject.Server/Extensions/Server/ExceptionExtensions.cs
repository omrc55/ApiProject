using BtkApiProject.Application.Exceptions.Common;
using BtkApiProject.Application.Interfaces.Services;
using BtkApiProject.Application.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BtkAkademiProject.Server.Extensions.Server;

public static class ExceptionExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication web, ILoggerService logger)
    {
        web.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotAddedException => StatusCodes.Status400BadRequest,
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    logger.LogError(contextFeature.Error.Message);
                    await context.Response.WriteAsync(new ErrorDetailModel()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message
                    }.ToString());
                }
            });
        });
    }

    public static void ConfigureApiBehavior(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
    }
}