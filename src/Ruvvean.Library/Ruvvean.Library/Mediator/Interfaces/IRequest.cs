using Ruvvean.Library.Models;

namespace Ruvvean.Library.Mediator.Interfaces;

/// <summary>
/// Defines a request that returns a response of type <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TResponse">
/// The type of response returned by the request. Must implement <see cref="IResult"/> and be non-null.
/// </typeparam>
public interface IRequest<TResponse>
    where TResponse : notnull, IResult;
