using Microsoft.Extensions.Configuration;

namespace APIConsumer
{
    internal class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService( HttpClient httpClient , IConfiguration config )
        {
            _httpClient = httpClient;
            IConfiguration _config = config;

            // Inject Authentication Header.
            var token = _config ["ApiSettings:AuthToken"];

            if ( !string.IsNullOrWhiteSpace(token) )
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer" , token);
            }
        }

        public async Task<string?> GetStatusAsync()
        {
            // Example GET request to /status endpoint.
            return await _httpClient.GetStringAsync("status");
        }
    }
}
