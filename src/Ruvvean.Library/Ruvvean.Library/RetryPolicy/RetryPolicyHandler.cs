using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace Ruvvean.Library.RetryPolicy;

/// <inheritdoc cref="IRetryPolicyHandler"/>
public class RetryPolicyHandler(ILoggerFactory loggerFactory) : IRetryPolicyHandler
{
    private readonly ILogger<RetryPolicyHandler> logger = loggerFactory.CreateLogger<RetryPolicyHandler>();

    /// <inheritdoc/>
    public void Excecute(Action action, int retryCount = 3, Type[]? exceptionTypes = null)
    {
        var retryPolicy = this.GetRetryPolicy(retryCount, exceptionTypes);
        retryPolicy.Execute(action);
    }

    /// <inheritdoc/>
    public TResult Execute<TResult>(Func<TResult> func, int retryCount = 3, Type[]? exceptionTypes = null)
    {
        var retryPolicy = this.GetRetryPolicy(retryCount, exceptionTypes);
        return retryPolicy.Execute(func);
    }

    /// <inheritdoc/>
    public async Task ExecuteAsync(Func<CancellationToken, Task> action, int retryCount = 3, Type[]? exceptionTypes = null, CancellationToken cancellationToken = default)
    {
        var retryPolicy = this.GetRetryPolicyAsync(retryCount, exceptionTypes);
        await retryPolicy.ExecuteAsync(action, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<TResult> ExecuteAsync<TResult>(Func<CancellationToken, Task<TResult>> func, int retryCount = 3, Type[]? exceptionTypes = null, CancellationToken cancellationToken = default)
    {
        var retryPolicy = this.GetRetryPolicyAsync(retryCount, exceptionTypes);
        return retryPolicy.ExecuteAsync(func, cancellationToken);
    }

    private Polly.Retry.RetryPolicy GetRetryPolicy(int retryCount, Type[]? exceptionTypes)
    {
        Type[] handled = (exceptionTypes != null && exceptionTypes.Length > 0)
            ? exceptionTypes
            : [typeof(Exception)];

        var policyBuilder = Policy.Handle<Exception>(ex => handled[0].IsInstanceOfType(ex));

        for (int i = 1; i < handled.Length; i++)
        {
            var t = handled[i];
            policyBuilder = policyBuilder.Or<Exception>(ex => t.IsInstanceOfType(ex));
        }

        return policyBuilder.WaitAndRetry(
            retryCount,
            retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
            onRetry: (ex, timeSpan, retryCount, context) => logger.LogWarning(ex, "Retry {RetryCount} after {TimeSpan} due to {ExceptionType}", retryCount, timeSpan, ex.GetType().Name));
    }

    private AsyncRetryPolicy GetRetryPolicyAsync(int retryCount, Type[]? exceptionTypes)
    {
        Type[] handled = (exceptionTypes != null && exceptionTypes.Length > 0)
            ? exceptionTypes
            : [typeof(Exception)];

        var policyBuilder = Policy.Handle<Exception>(ex => handled[0].IsInstanceOfType(ex));

        for (int i = 1; i < handled.Length; i++)
        {
            var t = handled[i];
            policyBuilder = policyBuilder.Or<Exception>(ex => t.IsInstanceOfType(ex));
        }

        return policyBuilder.WaitAndRetryAsync(
            retryCount,
            retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
            onRetry: (ex, timeSpan, retryCount, context) => logger.LogWarning(ex, "Retry {RetryCount} after {TimeSpan} due to {ExceptionType}", retryCount, timeSpan, ex.GetType().Name));
    }
}
