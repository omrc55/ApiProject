using BtkApiProject.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace BtkApiProject.Infrastructure.Services;

public class LoggerService(ILogger<LoggerService> logger) : ILoggerService
{
    private readonly ILogger<LoggerService> _logger = logger;

    public void LogDebug(string message) => _logger.LogDebug(message);

    public void LogError(string message) => _logger.LogError(message);

    public void LogInfo(string message) => _logger.LogInformation(message);

    public void LogWarning(string message) => _logger.LogWarning(message);
}