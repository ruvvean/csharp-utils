using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Context;
using System.Diagnostics;

namespace Ruvvean.Library.CorrelationId;

/// <summary>
/// Middleware that ensures each HTTP request has a correlation ID for tracking across distributed
/// systems. Adds the correlation ID to the response header and logging context.
/// </summary>
public sealed class CorrelationIdMiddleware(RequestDelegate next)
{
    /// <summary>
    /// The name of the HTTP header used for the correlation ID.
    /// </summary>
    public const string HeaderName = "X-Correlation-ID";

    private readonly RequestDelegate next = next;

    /// <summary>
    /// Processes an HTTP request, ensuring a correlation ID is present and added to the response
    /// and logging context.
    /// </summary>
    /// <param name="context">The current HTTP context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Invoke(HttpContext context)
    {
        var correlationId = GetOrCreateCorrelationId(context);

        context.Response.OnStarting(() =>
        {
            if (!context.Response.Headers.ContainsKey(HeaderName))
            {
                context.Response.Headers.Add(HeaderName, correlationId);
            }

            return Task.CompletedTask;
        });

        Activity.Current?.SetTag("correlation.id", correlationId);

        bool isSerilogConfigured = Log.Logger != null &&
                               Log.Logger.GetType().Name.Contains("Serilog", StringComparison.OrdinalIgnoreCase);

        if (isSerilogConfigured)
        {
            using (LogContext.PushProperty("CorrelationId", correlationId))
            {
                await this.next(context);
            }
        }
    }

    private static string GetOrCreateCorrelationId(HttpContext context)
    {
        if (context.Request.Headers.TryGetValue(HeaderName, out var value) &&
            !string.IsNullOrWhiteSpace(value))
        {
            return value.ToString();
        }

        return Guid.NewGuid().ToString("N");
    }
}
