using Ruvvean.Library.Models;

namespace Ruvvean.Library.Mediator.Interfaces;

/// <summary>
/// Defines a pipeline behavior for handling requests and responses.
/// </summary>
/// <typeparam name="TRequest">The type of request.</typeparam>
public interface IPipelineBehavior<TRequest>
    where TRequest : notnull, IRequest<IResult>
{
    /// <summary>
    /// Executes logic after the request has been handled and a response has been generated.
    /// </summary>
    /// <param name="request">The request instance.</param>
    /// <param name="response">The response instance.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{IResult}"/> representing the asynchronous operation, containing the result
    /// of the post-processing logic.
    /// </returns>
    Task<IResult> AfterAsync(TRequest request, IResult response, CancellationToken cancellationToken);

    /// <summary>
    /// Executes logic before the request is handled.
    /// </summary>
    /// <param name="request">The request instance.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{IResult}"/> representing the asynchronous operation, containing the result
    /// of the pre-processing logic.
    /// </returns>
    Task<IResult> BeforeAsync(TRequest request, CancellationToken cancellationToken);
}
