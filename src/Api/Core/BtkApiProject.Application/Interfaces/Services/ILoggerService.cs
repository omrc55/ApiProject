namespace BtkApiProject.Application.Interfaces.Services;

public interface ILoggerService
{
    void LogDebug(string message);
    void LogError(string message);
    void LogWarning(string message);
    void LogInfo(string message);
}