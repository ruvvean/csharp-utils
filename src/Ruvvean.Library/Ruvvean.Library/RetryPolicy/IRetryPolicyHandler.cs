namespace Ruvvean.Library.RetryPolicy;

/// <summary>
/// Defines a handler for executing actions and functions with retry logic.
/// </summary>
public interface IRetryPolicyHandler
{
    /// <summary>
    /// The default maximum number of retry attempts.
    /// </summary>
    public const int DefaultMaxRetryCount = 3;

    /// <summary>
    /// The default types of exceptions to handle for retry logic.
    /// </summary>
    public static readonly Type[] DefaultExceptionTypes = [typeof(Exception)];

    /// <summary>
    /// Executes the specified synchronous action with retry logic.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    /// <param name="retryCount">The maximum number of retry attempts. Defaults to <see cref="DefaultMaxRetryCount"/>.</param>
    /// <param name="exceptionTypes">
    /// The types of exceptions to handle for retry logic. If <c>null</c>, all exceptions are retried.
    /// </param>
    void Excecute(Action action, int retryCount = DefaultMaxRetryCount, Type[]? exceptionTypes = null);

    /// <summary>
    /// Executes the specified synchronous function with retry logic and returns its result.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the function.</typeparam>
    /// <param name="func">The function to execute.</param>
    /// <param name="retryCount">The maximum number of retry attempts. Defaults to <see cref="DefaultMaxRetryCount"/>.</param>
    /// <param name="exceptionTypes">
    /// The types of exceptions to handle for retry logic. If <c>null</c>, all exceptions are retried.
    /// </param>
    /// <returns>The result of the function.</returns>
    TResult Execute<TResult>(Func<TResult> func, int retryCount = DefaultMaxRetryCount, Type[]? exceptionTypes = null);

    /// <summary>
    /// Executes the specified asynchronous action with retry logic.
    /// </summary>
    /// <param name="action">
    /// The asynchronous action to execute. The action should return a <see cref="Task"/>.
    /// </param>
    /// <param name="retryCount">The maximum number of retry attempts. Defaults to <see cref="DefaultMaxRetryCount"/>.</param>
    /// <param name="exceptionTypes">
    /// The types of exceptions to handle for retry logic. If <c>null</c>, all exceptions are retried.
    /// </param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> to observe while waiting for the task to complete.
    /// </param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task ExecuteAsync(Func<CancellationToken, Task> action, int retryCount = DefaultMaxRetryCount, Type[]? exceptionTypes = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Executes the specified asynchronous function with retry logic and returns its result.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the function.</typeparam>
    /// <param name="func">
    /// The asynchronous function to execute. The function should return a <see cref="Task{TResult}"/>.
    /// </param>
    /// <param name="retryCount">The maximum number of retry attempts. Defaults to <see cref="DefaultMaxRetryCount"/>.</param>
    /// <param name="exceptionTypes">
    /// The types of exceptions to handle for retry logic. If <c>null</c>, all exceptions are retried.
    /// </param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> to observe while waiting for the task to complete.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous operation, containing the
    /// result of the function.
    /// </returns>
    Task<TResult> ExecuteAsync<TResult>(Func<CancellationToken, Task<TResult>> func, int retryCount = DefaultMaxRetryCount, Type[]? exceptionTypes = null, CancellationToken cancellationToken = default);
}
