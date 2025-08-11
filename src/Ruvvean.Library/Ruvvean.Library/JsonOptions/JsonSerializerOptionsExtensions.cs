using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ruvvean.Library.JsonOptions;

/// <summary>
/// Provides extension methods for configuring <see cref="JsonSerializerOptions"/> with predefined
/// default settings for consistent JSON serialization across the application.
/// </summary>
public static class JsonSerializerOptionsExtensions
{
    /// <summary>
    /// Adds a default JSON serialization configuration to the specified <see
    /// cref="JsonSerializerOptions"/>, enabling consistent formatting, string-based enum handling,
    /// and flexible parsing.
    /// </summary>
    /// <param name="options">The <see cref="JsonSerializerOptions"/> instance to configure.</param>
    /// <returns>
    /// The same <see cref="JsonSerializerOptions"/> instance with the default configuration applied.
    /// </returns>
    public static JsonSerializerOptions AddDefaultJsonOptions(this JsonSerializerOptions options)
    {
        options.AllowTrailingCommas = true;
        options.Converters.Add(new JsonStringEnumConverter());
        options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString |
            JsonNumberHandling.WriteAsString;
        options.PropertyNameCaseInsensitive = true;
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.WriteIndented = true;

        return options;
    }
}
