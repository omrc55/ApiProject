using BtkApiProject.Application.Interfaces.Services;
using BtkApiProject.Application.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace BtkApiProject.Presentation.ActionFilters;

public class LogFilterAttribute(ILoggerService loggerService) : ActionFilterAttribute
{
    private readonly ILoggerService _loggerService = loggerService;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _loggerService.LogInfo(Log("OnActionExecuting", context.RouteData));
    }

    private static string Log(string modelName, RouteData routeData)
    {
        var logDetails = new LogDetailModel
        {
            ModelName = modelName,
            Controller = routeData.Values["controller"],
            Action = routeData.Values["action"]
        };

        if (routeData.Values.Count >= 3)
            logDetails.ID = routeData.Values["id"];

        return logDetails.ToString();
    }
}