using Serilog;
using Serilog.Events;

public static class Logger
{
    public static void Initialize()
    {
        var cfg = ConfigurationManager.Config.Logging;

        var level = Enum.TryParse<LogEventLevel>(cfg.MinimumLevel, true, out var parsed)
            ? parsed
            : LogEventLevel.Information;

        var config = new LoggerConfiguration().MinimumLevel.Is(level);

        if (cfg.EnableConsole)
            config = config.WriteTo.Console();

        if (cfg.EnableFile && !string.IsNullOrWhiteSpace(cfg.FilePath))
            config = config.WriteTo.File(
                path: cfg.FilePath,
                rollingInterval: RollingInterval.Day,
                flushToDiskInterval: TimeSpan.FromSeconds(1),
                shared: true
            );

        Log.Logger = config.CreateLogger();
    }

    public static void Shutdown()
    {
        Log.CloseAndFlush();
    }
}
