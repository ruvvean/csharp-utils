using System.Diagnostics;

namespace Ruvvean.Library.Metrics;

/// <summary>
/// Provides utility methods for measuring execution time of code blocks.
/// </summary>
public static class Measure
{
    /// <summary>
    /// Measures the execution time of the specified function and optionally reports the elapsed time.
    /// </summary>
    /// <typeparam name="T">The return type of the function to execute.</typeparam>
    /// <param name="f">The function to execute and measure.</param>
    /// <param name="report">
    /// An optional action to receive the elapsed <see cref="TimeSpan"/> after execution. If
    /// <c>null</c>, no reporting is performed.
    /// </param>
    /// <returns>The result of the executed function <paramref name="f"/>.</returns>
    public static T Time<T>(Func<T> f, Action<TimeSpan>? report = null)
    {
        var sw = Stopwatch.StartNew();
        var result = f();
        sw.Stop();
        report?.Invoke(sw.Elapsed);
        return result;
    }
}
