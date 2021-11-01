using System.Net;

namespace FlaivySharp.Infrastructure
{
    /// <summary>
    /// An exception thrown when an API call has reached FlaivySharp's rate limit.
    /// </summary>
    public class FlaivyRateLimitException : FlaivyException
    {
        public FlaivyRateLimitException()
        { }

        public FlaivyRateLimitException(string message) : base(message) { }

        public FlaivyRateLimitException(HttpStatusCode httpStatusCode, string message, int code, string error) : base(httpStatusCode, message, code, error) { }
    }
}