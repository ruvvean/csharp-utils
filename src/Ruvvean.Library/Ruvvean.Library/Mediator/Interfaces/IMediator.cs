using Ruvvean.Library.Models;

namespace Ruvvean.Library.Mediator.Interfaces;

/// <summary>
/// Defines a mediator for sending requests and receiving results.
/// </summary>
public interface IMediator
{
    /// <summary>
    /// Sends a request asynchronously and returns the result.
    /// </summary>
    /// <param name="request">The request to send.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the <see
    /// cref="IResult"/> of the request.
    /// </returns>
    Task<IResult> SendAsync(IRequest<IResult> request, CancellationToken cancellationToken = default);
}
