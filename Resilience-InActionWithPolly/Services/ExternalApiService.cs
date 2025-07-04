namespace Resilience_InActionWithPolly.Services
{
    public class ExternalApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExternalApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetDataAsync()
        {
            var client = _httpClientFactory.CreateClient("ExternalApi");
            var response = await client.GetAsync("posts/2");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
