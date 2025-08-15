using Ruvvean.Library.Mediator.Interfaces;
using Ruvvean.Library.Models;

namespace Ruvvean.Library.Mediator;

/// <summary>
/// Provides an implementation of the <see cref="IMediator"/> interface for sending requests and
/// receiving results.
/// </summary>
/// <remarks>
/// The <see cref="Mediator"/> resolves request handlers and pipeline behaviors from the provided
/// <see cref="IServiceProvider"/>.
/// </remarks>
public sealed class Mediator(IServiceProvider serviceProvider) : IMediator
{
    /// <summary>
    /// The service provider used to resolve handlers and pipeline behaviors.
    /// </summary>
    private readonly IServiceProvider serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

    /// <summary>
    /// Sends a request asynchronously through the mediator, optionally executing pipeline behaviors.
    /// </summary>
    /// <param name="request">The request to send.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the <see
    /// cref="IResult"/> of the request.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no handler is registered for the request type.
    /// </exception>
    public async Task<IResult> SendAsync(IRequest<IResult> request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null.");
        }

        var requestType = request.GetType();
        var handlerType = typeof(IRequestHandler<>).MakeGenericType(requestType);
        var handler = serviceProvider.GetService(handlerType)
            ?? throw new InvalidOperationException($"No handler registered for request type {requestType.Name}.");

        var pipelineType = typeof(IPipelineBehavior<>).MakeGenericType(requestType);
        var pipeline = serviceProvider.GetService(pipelineType);

        if (pipeline is null)
        {
            return await ((dynamic)handler).HandleAsync((dynamic)request, cancellationToken);
        }

        return await ExecuteWithPipelineAsync((dynamic)pipeline, (dynamic)request, (dynamic)handler, cancellationToken);
    }

    /// <summary>
    /// Executes the request using the specified pipeline behavior and handler.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <param name="pipeline">The pipeline behavior to execute before and after the handler.</param>
    /// <param name="request">The request instance.</param>
    /// <param name="handler">The handler to process the request.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the <see
    /// cref="IResult"/> of the request.
    /// </returns>
    private static async Task<IResult> ExecuteWithPipelineAsync<TRequest>(
        IPipelineBehavior<TRequest> pipeline,
        TRequest request,
        IRequestHandler<TRequest> handler,
        CancellationToken cancellationToken)
        where TRequest : IRequest<IResult>
    {
        var before = await pipeline.BeforeAsync(request, cancellationToken);
        if (!before.IsSuccess)
        {
            return before;
        }

        var result = await handler.HandleAsync(request, cancellationToken);

        var after = await pipeline.AfterAsync(request, result, cancellationToken);
        return !after.IsSuccess ? after : result;
    }
}
