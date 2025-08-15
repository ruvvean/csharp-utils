using Ruvvean.Library.Models;

namespace Ruvvean.Library.Mediator.Interfaces;

/// <summary>
/// Defines a handler for processing requests that produce a response.
/// </summary>
/// <typeparam name="TRequest">The type of request to handle. Must implement <see cref="IRequest{IResult}"/>.</typeparam>
public interface IRequestHandler<in TRequest>
    where TRequest : IRequest<IResult>
{
    /// <summary>
    /// Asynchronously handles the specified request and returns a result.
    /// </summary>
    /// <param name="request">The request to process.</param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A <see cref="Task{IResult}"/> representing the asynchronous operation, containing the result
    /// of the request.
    /// </returns>
    Task<IResult> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
}
