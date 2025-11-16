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
        private readonly IConfiguration _configuration;

        public Application(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Run()
        {
            var text = _configuration["ApiSettings:BaseUri"];
            Console.WriteLine($"My API URL is: {text}");
        }
    }
}
