namespace Ruvvean.Library.Models;

/// <summary>
/// Represents the result of an operation, providing information about success or failure.
/// </summary>
public interface IResult
{
    /// <summary>
    /// Gets the error code if the result is a failure. Returns <c>null</c> if the result is successful.
    /// </summary>
    int? Code { get; }

    /// <summary>
    /// Gets the error messages if the result is a failure. Returns <c>null</c> if the result is successful.
    /// </summary>
    string[]? ErrorMessages { get; }

    /// <summary>
    /// Gets a value indicating whether the result is successful.
    /// </summary>
    bool IsSuccess { get; }

    /// <summary>
    /// The default error code used when no specific error code is provided.
    /// </summary>
    protected const int DefaultErrorCode = -1;
}