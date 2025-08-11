using Serilog;
using Serilog.Events;

namespace Ruvvean.Library.SerilogConfiguration;

/// <summary>
/// Provides preset methods for creating Serilog <see cref="ILogger"/> instances with recommended
/// configurations for debug and production environments.
/// </summary>
public static class SerilogLoggerPresets
{
    private const string DefaultConsoleTemplate = "[{Timestamp:HH:mm:ss} {Level:u3} Cid={CorrelationId}] {Message:lj} {Properties:j}{NewLine}{Exception}";
    private const string DefaultFileTemplate = "{Timestamp:O} [{Level:u3} Cid={CorrelationId}] {Message:lj} {Properties:j}{NewLine}{Exception}";

    /// <summary>
    /// Creates a Serilog <see cref="ILogger"/> configured for debugging, with optional file and
    /// console output templates.
    /// </summary>
    /// <param name="logEventLevel">
    /// The minimum log event level for Microsoft and System sources. Default is <see cref="LogEventLevel.Debug"/>.
    /// </param>
    /// <param name="logFileName">
    /// Optional file path for logging to a file. If null or whitespace, file logging is disabled.
    /// </param>
    /// <param name="consoleTemplate">
    /// Optional output template for console logs. If null, a default template is used.
    /// </param>
    /// <param name="fileTemplate">
    /// Optional output template for file logs. If null, a default template is used.
    /// </param>
    /// <returns>A configured <see cref="ILogger"/> instance for debugging.</returns>
    public static ILogger CreateDebugLogger(LogEventLevel logEventLevel = LogEventLevel.Debug, string? logFileName = null, string? consoleTemplate = null, string? fileTemplate = null)
    {
        var configuration = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", logEventLevel)
            .MinimumLevel.Override("Microsoft.AspNetCore", logEventLevel)
            .MinimumLevel.Override("System", logEventLevel)
            .Enrich.FromLogContext()
            .WriteTo.Console(
                outputTemplate: consoleTemplate ?? DefaultConsoleTemplate);

        if (!string.IsNullOrWhiteSpace(logFileName))
        {
            configuration.WriteTo.File(
                path: logFileName,
                rollingInterval: RollingInterval.Day,
                restrictedToMinimumLevel: logEventLevel,
                shared: true,
                outputTemplate: fileTemplate ?? DefaultFileTemplate);
        }

        return configuration.CreateLogger();
    }

    /// <summary>
    /// Creates a Serilog <see cref="ILogger"/> configured for production, with optional file and
    /// console output templates.
    /// </summary>
    /// <param name="logEventLevel">
    /// The minimum log event level for Microsoft and System sources. Default is <see cref="LogEventLevel.Warning"/>.
    /// </param>
    /// <param name="logFileName">
    /// Optional file path for logging to a file. If null or whitespace, file logging is disabled.
    /// </param>
    /// <param name="consoleTemplate">
    /// Optional output template for console logs. If null, a default template is used.
    /// </param>
    /// <param name="fileTemplate">
    /// Optional output template for file logs. If null, a default template is used.
    /// </param>
    /// <returns>A configured <see cref="ILogger"/> instance for production use.</returns>
    public static ILogger CreateProductionLogger(LogEventLevel logEventLevel = LogEventLevel.Warning, string? logFileName = null, string? consoleTemplate = null, string? fileTemplate = null)
    {
        var configuration = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .MinimumLevel.Override("Microsoft", logEventLevel)
            .MinimumLevel.Override("Microsoft.AspNetCore", logEventLevel)
            .MinimumLevel.Override("System", logEventLevel)
            .Enrich.FromLogContext()
            .WriteTo.Console(
                outputTemplate: consoleTemplate ?? DefaultConsoleTemplate);

        if (!string.IsNullOrWhiteSpace(logFileName))
        {
            configuration.WriteTo.File(
                path: "logs/debug-log-.txt",
                rollingInterval: RollingInterval.Day,
                restrictedToMinimumLevel: logEventLevel,
                shared: true,
                outputTemplate: fileTemplate ?? DefaultFileTemplate);
        }

        return configuration.CreateLogger();
    }
}
