using Microsoft.AspNetCore.Builder;

namespace Ruvvean.Library.CorrelationId;

/// <summary>
/// Provides extension methods for registering the <see cref="CorrelationIdMiddleware"/> in the
/// application's request pipeline.
/// </summary>
public static class CorelationIdMiddlewareExtensions
{
    /// <summary>
    /// Adds the <see cref="CorrelationIdMiddleware"/> to the application's request pipeline. This
    /// middleware assigns a correlation ID to each incoming HTTP request for tracking purposes.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/> to configure.</param>
    /// <returns>The <see cref="IApplicationBuilder"/> instance for chaining.</returns>
    public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
        => app.UseMiddleware<CorrelationIdMiddleware>();
}
