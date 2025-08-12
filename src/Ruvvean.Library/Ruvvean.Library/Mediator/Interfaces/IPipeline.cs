namespace Ruvvean.Library.Mediator.Interfaces;

/// <summary>
/// Represents the next delegate in the request handling pipeline.
/// </summary>
/// <typeparam name="TResponse">
/// The type of the response returned by the request handler. Must be a non-nullable type.
/// </typeparam>
/// <returns>
/// A task that represents the asynchronous operation, containing the response of type <typeparamref name="TResponse"/>.
/// </returns>
public delegate Task<TResponse> RequestHandlerDelegate<TResponse>();

/// <summary>
/// Defines a behavior in the request handling pipeline that can be executed before and/or after the
/// request handler.
/// </summary>
/// <typeparam name="TRequest">The type of the request. Must implement <see cref="IRequest{TResponse}"/>.</typeparam>
/// <typeparam name="TResponse">
/// The type of the response returned by the request handler. Must be a non-nullable type.
/// </typeparam>
/// <remarks>
/// Pipeline behaviors are executed in the order they are registered, wrapping the execution of the
/// next behavior or the request handler. This allows for cross-cutting concerns such as logging,
/// validation, transaction handling, or caching.
/// </remarks>
public interface IPipelineBehavior<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    /// <summary>
    /// Handles the incoming request and optionally invokes the next delegate in the pipeline.
    /// </summary>
    /// <param name="request">The request to be processed.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    /// <param name="next">
    /// The delegate representing the next step in the pipeline or the final request handler.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation, containing the response of type
    /// <typeparamref name="TResponse"/>.
    /// </returns>
    Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken);
}
