namespace Ruvvean.Library.Mediator.Interfaces;

/// <summary>
/// Marker interface representing a request to be handled by a request handler.
/// </summary>
/// <remarks>
/// This interface does not define any members and is typically used to unify both requests with and
/// without return values under a common type.
/// </remarks>
public interface IRequest;

/// <summary>
/// Represents a request to be handled by a request handler that produces a response.
/// </summary>
/// <typeparam name="TResponse">
/// The type of the response expected from handling the request. Must be a non-nullable type.
/// </typeparam>
/// <remarks>
/// This interface extends <see cref="IRequest"/> and is used for requests that return a value when processed.
/// </remarks>
public interface IRequest<TResponse> : IRequest
    where TResponse : notnull;
