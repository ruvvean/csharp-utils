using Microsoft.AspNetCore.Http;

namespace Ruvvean.Library.CorrelationId;

/// <summary>
/// DelegatingHandler that adds a correlation ID header to outgoing HTTP requests.
/// </summary>
/// <remarks>Initializes a new instance of the <see cref="CorrelationIdHandler"/> class.</remarks>
/// <param name="httpContextAccessor">The accessor for the current HTTP context.</param>
public class CorrelationIdHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
{
    /// <summary>
    /// Provides access to the current HTTP context.
    /// </summary>
    private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

    /// <summary>
    /// Adds the correlation ID header to the outgoing HTTP request if it is present in the current
    /// HTTP response headers.
    /// </summary>
    /// <param name="request">The outgoing HTTP request message.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A task representing the asynchronous operation, with the HTTP response message as result.
    /// </returns>
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var httpContext = this.httpContextAccessor.HttpContext;
        if (httpContext != null &&
            httpContext.Response.Headers.TryGetValue(CorrelationIdMiddleware.HeaderName, out var cid) &&
            !request.Headers.Contains(CorrelationIdMiddleware.HeaderName))
        {
            request.Headers.Add(CorrelationIdMiddleware.HeaderName, cid.ToString());
        }

        return base.SendAsync(request, cancellationToken);
    }
}
