/*******************************************************************************************
 * 
 * Auth: DRT
 * Date: 16/11/2025
 * 
 * Description: API service.
 * 
 ******************************************************************************************/

using Microsoft.Extensions.Configuration;

namespace APIConsumer
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor for injecting config and obtaining auth.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="config"></param>
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

        /// <summary>
        /// Uses 'GET' verb on '/posts' noun.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPostsAsync()
        {
            var posts = await _httpClient.GetStringAsync("posts");

            return posts; 
        }
    }
}
