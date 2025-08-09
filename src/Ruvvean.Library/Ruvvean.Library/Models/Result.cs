using System.Diagnostics.CodeAnalysis;

namespace Ruvvean.Library.Models;

/// <summary>
/// Represents the result of an operation, indicating success or failure.
/// </summary>
public readonly struct Result : IResult
{
    /// <inheritdoc/>
    public int? Code
    {
        get
        {
            if (this.IsSuccess)
            {
                return null;
            }

            return code ?? IResult.DefaultErrorCode;
        }
    }

    /// <inheritdoc/>
    public string[]? ErrorMessages
    {
        get
        {
            if (this.IsSuccess)
            {
                return null;
            }

            return this.errorMessages ?? [];
        }
    }

    /// <inheritdoc/>
    [MemberNotNullWhen(false, nameof(ErrorMessages))]
    [MemberNotNullWhen(false, nameof(Code))]
    public bool IsSuccess => this.errorMessages is null || this.errorMessages.Length == 0;

    private readonly int? code;
    private readonly string[]? errorMessages;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> struct.
    /// </summary>
    /// <param name="errorMessages">The error messages associated with the result.</param>
    /// <param name="code">The error code associated with the result.</param>
    private Result(string[]? errorMessages = null, int? code = null)
    {
        this.code = code;
        this.errorMessages = errorMessages;
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to a <see cref="bool"/> indicating success.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    /// <returns><c>true</c> if the result is successful; otherwise, <c>false</c>.</returns>
    public static explicit operator bool(Result result) => result.IsSuccess;

    /// <summary>
    /// Converts an array of error messages to a <see cref="Result"/> representing failure.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A <see cref="Result"/> representing failure.</returns>
    public static explicit operator Result(string[] errorMessages) => new(errorMessages);

    /// <summary>
    /// Converts a tuple containing an error code and error messages to a <see cref="Result"/>
    /// representing failure.
    /// </summary>
    /// <param name="tuple">A tuple containing the error code and error messages.</param>
    /// <returns>A <see cref="Result"/> representing failure.</returns>
    public static explicit operator Result((int?, string[]?) tuple) => new(tuple.Item2, tuple.Item1);

    /// <summary>
    /// Converts a <see cref="Result{T}"/> (with T as object) to a <see cref="Result"/>.
    /// </summary>
    /// <param name="result">The generic result to convert.</param>
    /// <returns>A <see cref="Result"/> with the same error messages and code.</returns>
    public static explicit operator Result(Result<object> result) => new(result.ErrorMessages, result.Code);

    /// <summary>
    /// Creates a <see cref="Result"/> representing failure with the specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A <see cref="Result"/> representing failure.</returns>
    public static Result Failure(params string[] errorMessages) => new(errorMessages);

    /// <summary>
    /// Creates a <see cref="Result"/> representing failure with the specified error code and error messages.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A <see cref="Result"/> representing failure.</returns>
    public static Result Failure(int code, params string[] errorMessages) => new(errorMessages, code);

    /// <summary>
    /// Creates a <see cref="Result"/> representing success.
    /// </summary>
    /// <returns>A <see cref="Result"/> representing success.</returns>
    public static Result Success() => new();
}

/// <summary>
/// Represents the result of an operation that returns a value, indicating success or failure.
/// </summary>
/// <typeparam name="T">The type of the value returned on success.</typeparam>
public readonly struct Result<T> : IResult
{
    /// <inheritdoc/>
    public int? Code
    {
        get
        {
            if (this.IsSuccess)
            {
                return null;
            }

            return code ?? IResult.DefaultErrorCode;
        }
    }

    /// <inheritdoc/>
    public string[]? ErrorMessages
    {
        get
        {
            if (this.IsSuccess)
            {
                return null;
            }

            return this.errorMessages ?? [];
        }
    }

    /// <inheritdoc/>
    [MemberNotNullWhen(true, nameof(Value))]
    [MemberNotNullWhen(false, nameof(ErrorMessages))]
    [MemberNotNullWhen(false, nameof(Code))]
    public bool IsSuccess => this.errorMessages is null || this.errorMessages.Length == 0;

    /// <summary>
    /// Gets the value returned by the operation if successful.
    /// </summary>
    public T? Value { get; }

    private readonly int? code;
    private readonly string[]? errorMessages;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> struct representing success.
    /// </summary>
    /// <param name="value">The value returned by the operation.</param>
    private Result(T? value) => this.Value = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> struct representing failure.
    /// </summary>
    /// <param name="errorMessages">The error messages associated with the result.</param>
    /// <param name="code">The error code associated with the result.</param>
    private Result(string[]? errorMessages = null, int? code = null)
    {
        this.code = code;
        this.errorMessages = errorMessages;
    }

    /// <summary>
    /// Converts a <see cref="Result{T}"/> to a <see cref="bool"/> indicating success.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    /// <returns><c>true</c> if the result is successful; otherwise, <c>false</c>.</returns>
    public static explicit operator bool(Result<T>? result) => result?.IsSuccess ?? false;

    /// <summary>
    /// Converts an array of error messages to a <see cref="Result{T}"/> representing failure.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A <see cref="Result{T}"/> representing failure.</returns>
    public static explicit operator Result<T>(string[]? errorMessages) => new(errorMessages);

    /// <summary>
    /// Converts a tuple containing an error code and error messages to a <see cref="Result{T}"/>
    /// representing failure.
    /// </summary>
    /// <param name="tuple">A tuple containing the error code and error messages.</param>
    /// <returns>A <see cref="Result{T}"/> representing failure.</returns>
    public static explicit operator Result<T>((int?, string[]?) tuple) => new(tuple.Item2, tuple.Item1);

    /// <summary>
    /// Converts a <see cref="Result"/> to a <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="result">The non-generic result to convert.</param>
    /// <returns>A <see cref="Result{T}"/> with the same error messages and code.</returns>
    public static explicit operator Result<T>(Result result) => new(result.ErrorMessages, result.Code);

    /// <summary>
    /// Creates a <see cref="Result{T}"/> representing failure with the specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A <see cref="Result{T}"/> representing failure.</returns>
    public static Result<T> Failure(params string[] errorMessages) => new(errorMessages);

    /// <summary>
    /// Creates a <see cref="Result{T}"/> representing failure with the specified error code and
    /// error messages.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A <see cref="Result{T}"/> representing failure.</returns>
    public static Result<T> Failure(int code, params string[] errorMessages) => new(errorMessages, code);

    /// <summary>
    /// Creates a <see cref="Result{T}"/> representing success with the specified value.
    /// </summary>
    /// <param name="value">The value returned by the operation.</param>
    /// <returns>A <see cref="Result{T}"/> representing success.</returns>
    public static Result<T> Success(T value) => new(value);
}
