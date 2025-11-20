/*******************************************************************************************
 * 
 * Auth: DRT
 * Date: 16/11/2025
 * 
 * Description: 
 * 
 * Main application.
 * 
 ******************************************************************************************/

using Microsoft.Extensions.Configuration;

namespace APIConsumer
{
    public class Application
    {
        // This configuration is injected by the DI container i.e.the config
        // that's built using HostApplicationBuilder.
        private readonly IConfiguration _configuration;

        // API service to use throughout Application.
        private readonly IApiService _apiService;

        // This says 0 references but is false positive, since static code
        // analysis doesn't register that it's DI based activation.
        public Application( IConfiguration configuration, IApiService apiService )
        {
            _configuration = configuration;
            _apiService = apiService;
        }

        // Main method.
        public async Task Run()
        {
            var text = _configuration ["ApiSettings:BaseUri"];
            var posts = await _apiService.GetPostsAsync();

            Console.WriteLine($"My API URL is: {text}");
            Console.WriteLine($"TEST: {posts}");
        }
    }
}
