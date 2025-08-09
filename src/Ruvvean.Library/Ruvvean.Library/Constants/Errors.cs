namespace Ruvvean.Library.Constants;

/// <summary>
/// Provides constants for common HTTP error responses.
/// </summary>
public static class Errors
{
    /// <summary>
    /// Contains constants for the 400 Bad Request error.
    /// </summary>
    public static class BadRequest
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "Invalid request payload";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Bad Request";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1";
    }

    /// <summary>
    /// Contains constants for the 409 Conflict error.
    /// </summary>
    public static class Conflict
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The request could not be completed due to a conflict with the current state of the resource";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Conflict";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.10";
    }

    /// <summary>
    /// Contains constants for the 417 Expectation Failed error.
    /// </summary>
    public static class ExpectationFailed
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The server cannot meet the requirements of the Expect request-header field";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Expectation Failed";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.18";
    }

    /// <summary>
    /// Contains constants for the 424 Failed Dependency error.
    /// </summary>
    public static class FailedDependency
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The request failed due to failure of a previous request";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Failed Dependency";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc4918#section-11.4";
    }

    /// <summary>
    /// Contains constants for the 403 Forbidden error.
    /// </summary>
    public static class Forbidden
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "You do not have permission to access this resource";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Forbidden";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.4";
    }

    /// <summary>
    /// Contains constants for the 410 Gone error.
    /// </summary>
    public static class Gone
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The requested resource is no longer available";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Gone";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.11";
    }

    /// <summary>
    /// Contains constants for the 418 I'm a teapot error.
    /// </summary>
    public static class ImATeapot
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The server refuses to brew coffee because it is, permanently, a teapot";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "I'm a teapot";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.19";
    }

    /// <summary>
    /// Contains constants for the 500 Internal Server Error.
    /// </summary>
    public static class InternalServerError
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "Unknown error has occurred during data processing";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Internal Server Error";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.6.1";
    }

    /// <summary>
    /// Contains constants for the 411 Length Required error.
    /// </summary>
    public static class LengthRequired
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "Content-Length header is required";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Length Required";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.12";
    }

    /// <summary>
    /// Contains constants for the 423 Locked error.
    /// </summary>
    public static class Locked
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The resource that is being accessed is locked";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Locked";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc4918#section-11.3";
    }

    /// <summary>
    /// Contains constants for the 405 Method Not Allowed error.
    /// </summary>
    public static class MethodNotAllowed
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The method specified in the request is not allowed for the resource";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Method Not Allowed";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.6";
    }

    /// <summary>
    /// Contains constants for the 421 Misdirected Request error.
    /// </summary>
    public static class MisdirectedRequest
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The request was directed at a server that is not able to produce a response";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Misdirected Request";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.20";
    }

    /// <summary>
    /// Contains constants for the 406 Not Acceptable error.
    /// </summary>
    public static class NotAcceptable
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The requested resource is not capable of generating content acceptable according to the Accept headers";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Not Acceptable";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.7";
    }

    /// <summary>
    /// Contains constants for the 404 Not Found error.
    /// </summary>
    public static class NotFound
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The requested resource was not found";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Not Found";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.5";
    }

    /// <summary>
    /// Contains constants for the 413 Payload Too Large error.
    /// </summary>
    public static class PayloadTooLarge
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The request payload is too large";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Payload Too Large";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.14";
    }

    /// <summary>
    /// Contains constants for the 402 Payment Required error.
    /// </summary>
    public static class PaymentRequired
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "Payment is required to access this resource";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Payment Required";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.2";
    }

    /// <summary>
    /// Contains constants for the 412 Precondition Failed error.
    /// </summary>
    public static class PreconditionFailed
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "Precondition given in the request evaluated to false";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Precondition Failed";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.13";
    }

    /// <summary>
    /// Contains constants for the 428 Precondition Required error.
    /// </summary>
    public static class PreconditionRequired
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The server requires the request to be conditional";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Precondition Required";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc6585#section-3";
    }

    /// <summary>
    /// Contains constants for the 407 Proxy Authentication Required error.
    /// </summary>
    public static class ProxyAuthenticationRequired
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "Proxy authentication is required";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Proxy Authentication Required";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.8";
    }

    /// <summary>
    /// Contains constants for the 416 Range Not Satisfiable error.
    /// </summary>
    public static class RangeNotSatisfiable
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The requested range cannot be satisfied";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Range Not Satisfiable";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.17";
    }

    /// <summary>
    /// Contains constants for the 431 Request Header Fields Too Large error.
    /// </summary>
    public static class RequestHeaderFieldsTooLarge
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The server is unwilling to process the request because its header fields are too large";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Request Header Fields Too Large";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc6585#section-5";
    }

    /// <summary>
    /// Contains constants for the 408 Request Timeout error.
    /// </summary>
    public static class RequestTimeout
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The server timed out waiting for the request";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Request Timeout";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.9";
    }

    /// <summary>
    /// Contains constants for the 503 Service Unavailable error.
    /// </summary>
    public static class ServiceUnavailable
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The service is currently unavailable.";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Service Unavailable";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.6.4";
    }

    /// <summary>
    /// Contains constants for the 425 Too Early error.
    /// </summary>
    public static class TooEarly
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The server is unwilling to risk processing a request that might be replayed";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Too Early";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc8470#section-5.2";
    }

    /// <summary>
    /// Contains constants for the 429 Too Many Requests error.
    /// </summary>
    public static class TooManyRequests
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The user has sent too many requests in a given amount of time";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Too Many Requests";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc6585#section-4";
    }

    /// <summary>
    /// Contains constants for the 401 Unauthorized error.
    /// </summary>
    public static class Unauthorized
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "You are not authorized to access this resource";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Unauthorized";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.2";
    }

    /// <summary>
    /// Contains constants for the 451 Unavailable For Legal Reasons error.
    /// </summary>
    public static class UnavailableForLegalReasons
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The resource is unavailable for legal reasons";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Unavailable For Legal Reasons";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc7725#section-3";
    }

    /// <summary>
    /// Contains constants for the 422 Unprocessable Content error.
    /// </summary>
    public static class UnprocessableContent
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The server understands the content type of the request entity, but was unable to process the contained instructions";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Unprocessable Content";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.21";
    }

    /// <summary>
    /// Contains constants for the 415 Unsupported Media Type error.
    /// </summary>
    public static class UnsupportedMediaType
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The request entity has a media type which the server or resource does not support";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Unsupported Media Type";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.16";
    }

    /// <summary>
    /// Contains constants for the 426 Upgrade Required error.
    /// </summary>
    public static class UpgradeRequired
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The client should switch to a different protocol";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "Upgrade Required";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.22";
    }

    /// <summary>
    /// Contains constants for the 414 URI Too Long error.
    /// </summary>
    public static class UriTooLong
    {
        /// <summary>
        /// A description of the error.
        /// </summary>
        public const string Detail = "The requested URI is too long";

        /// <summary>
        /// The title of the error.
        /// </summary>
        public const string Title = "URI Too Long";

        /// <summary>
        /// The URI reference for the error type.
        /// </summary>
        public const string Type = "https://tools.ietf.org/html/rfc9110#section-15.5.15";
    }
}
