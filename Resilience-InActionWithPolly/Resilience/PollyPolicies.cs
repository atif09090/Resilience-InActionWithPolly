using Polly.Bulkhead;
using Polly.Extensions.Http;
using Polly;

namespace Resilience_InActionWithPolly.Resilience
{
    public static class PollyPolicies
    {
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
            => HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
            => HttpPolicyExtensions.HandleTransientHttpError()
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));

        public static IAsyncPolicy<HttpResponseMessage> GetTimeoutPolicy()
            => Policy.TimeoutAsync<HttpResponseMessage>(3); // 3 seconds

        public static IAsyncPolicy<HttpResponseMessage> GetFallbackPolicy()
            => Policy<HttpResponseMessage>
                .Handle<Exception>()
                .FallbackAsync(
                    fallbackAction: _ => Task.FromResult(new HttpResponseMessage
                    {
                        Content = new StringContent("{\"message\":\"Fallback response.\"}"),
                        StatusCode = System.Net.HttpStatusCode.OK
                    }));

        public static AsyncBulkheadPolicy<HttpResponseMessage> GetBulkheadPolicy()
            => Policy.BulkheadAsync<HttpResponseMessage>(maxParallelization: 2, maxQueuingActions: 4);
    }
}
