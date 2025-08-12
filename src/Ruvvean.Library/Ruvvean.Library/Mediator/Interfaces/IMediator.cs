namespace Ruvvean.Library.Mediator.Interfaces;

/// <summary>
/// Defines a mediator responsible for sending requests to their corresponding handlers.
/// </summary>
/// <remarks>
/// The mediator decouples the request initiator from its handling logic, allowing for a more
/// flexible and maintainable architecture. Supports sending both requests without return values and
/// requests that return a strongly-typed response.
/// </remarks>
public interface IMediator
{
    /// <summary>
    /// Asynchronously sends a request that does not produce a return value.
    /// </summary>
    /// <param name="request">The request implementing <see cref="IRequest"/> to be processed.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the send operation.</param>
    /// <returns>A task representing the asynchronous send operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is <c>null</c>.</exception>
    Task SendAsync(IRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously sends a request and waits for a strongly-typed response.
    /// </summary>
    /// <typeparam name="TResponse">
    /// The type of the expected response. Must be a non-nullable type.
    /// </typeparam>
    /// <param name="request">
    /// The request implementing <see cref="IRequest{TResponse}"/> to be processed.
    /// </param>
    /// <param name="cancellationToken">A token that can be used to cancel the send operation.</param>
    /// <returns>
    /// A task representing the asynchronous send operation, containing the response of type
    /// <typeparamref name="TResponse"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is <c>null</c>.</exception>
    Task<TResponse> SendAsync<TResponse>(
        IRequest<TResponse> request,
        CancellationToken cancellationToken = default)
        where TResponse : notnull;
}
