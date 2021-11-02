using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FlaivySharp.Infrastructure;
using FlaivySharp.Infrastructure.Policies;
using Newtonsoft.Json;

namespace FlaivySharp.Services
{
    public class FlaivyService
    {
        private static IRequestExecutionPolicy _GlobalExecutionPolicy = new DefaultRequestExecutionPolicy();

        private IRequestExecutionPolicy _ExecutionPolicy;

        private static HttpClient _Client { get; } = new HttpClient();

        protected string _accessToken { get; set; }


        /// <summary>
        /// Creates a new instance of <see cref="FlaivyService" />.
        /// </summary>
        /// <param name="accessToken">App Access token</param>
        protected FlaivyService(string accessToken)
        {
            _accessToken = accessToken;

            // If there's a global execution policy it should be set as this instance's policy.
            // User can override it with instance-specific execution policy.
            _ExecutionPolicy = _GlobalExecutionPolicy ?? new DefaultRequestExecutionPolicy();
        }

        protected RequestUri PrepareRequest(string path)
        {
            return new RequestUri(new Uri($"https://dev.flaivy.com/integrations/exacta/{path}"));
        }

        /// <summary>
        /// Prepares a request to the path and appends the shop's access token header if applicable.
        /// </summary>
        public CloneableRequestMessage PrepareRequestMessage(RequestUri uri, HttpMethod method, HttpContent content = null)
        {
            var msg = new CloneableRequestMessage(uri.ToUri(), method, content);
            msg.Headers.Add("Content-Type", "application/json");
            msg.Headers.Authorization = new AuthenticationHeaderValue("Bearer ", _accessToken);
            return msg;
        }

        /// <summary>
        /// Executes a request and returns the given type. Throws an exception when the response is invalid.
        /// Use this method when the expected response is a single line or simple object that doesn't warrant its own class.
        /// </summary>
        protected async Task<T> ExecuteRequestAsync<T>(RequestUri uri, HttpMethod method, HttpContent content = null)
        {
            using (var baseRequestMessage = PrepareRequestMessage(uri, method, content))
            {
                var policyResult = await _ExecutionPolicy.Run(baseRequestMessage, async requestMessage =>
                {
                    var request = _Client.SendAsync(requestMessage);

                    using (var response = await request)
                    {
                        var rawResult = await response.Content.ReadAsStringAsync();

                        //Check for and throw exception when necessary.
                        CheckResponseExceptions(response, rawResult);

                        // This method may fail when the method was Delete, which is intendend.
                        // Delete methods should not be parsing the response JSON and should instead
                        // be using the non-generic ExecuteRequestAsync.

                        var result = JsonConvert.DeserializeObject<T>(rawResult);
                        return new RequestResult<T>(response, result, rawResult);
                    }
                });

                return policyResult;
            }
        }

        /// <summary>
        /// Checks a response for exceptions or invalid status codes. Throws an exception when necessary.
        /// </summary>
        /// <param name="response">The response.</param>
        public static void CheckResponseExceptions(HttpResponseMessage response, string rawResponse)
        {
            var statusCode = (int)response.StatusCode;

            // No error if response was between 200 and 300.
            if (statusCode >= 200 && statusCode < 300)
            {
                return;
            }

            var code = response.StatusCode;

            // If the error was caused by reaching the API rate limit, throw a rate limit exception.
            if ((int)code == 429 /* Too many requests */)
            {
                var listMessage = "Exceeded 2 calls per second for api client. Reduce request rates to resume uninterrupted service.";
                var error = JsonConvert.DeserializeObject<FlaivyRateLimitException>(rawResponse);
                if (error != null)
                {
                    error.HttpStatusCode = code;
                    error.Message = listMessage;
                    throw error;
                }
            }

            var defaultMessage = $"Response did not indicate success. Status: {(int)code} {response.ReasonPhrase}.";

            FlaivyException exception;
            try
            {
                exception = JsonConvert.DeserializeObject<FlaivyException>(rawResponse);
            }
            catch (Exception)
            {
                throw new FlaivyException(defaultMessage) { HttpStatusCode = code };
            }

            if (exception == null) return;

            exception.HttpStatusCode = code;
            exception.Message ??= $"{defaultMessage}-{exception.Error}";
            throw exception;
        }
    }
}
