using Serilog;

namespace PracticalTask.ClientUI.Loggers;

public sealed class LoggerFactory
{
    public static ILogger GetLogger()
    {
        return new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("./logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }
}