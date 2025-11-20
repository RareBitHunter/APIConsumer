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
    /// <summary>
    /// Main program application.
    /// </summary>
    public class Application
    {
        // This configuration is injected by the DI container i.e.the config
        // that's built using HostApplicationBuilder.
        private readonly IConfiguration _configuration;

        // This says 0 references but is false positive, since static code analysis
        // doesn't register that it's DI based activation.
        public Application( IConfiguration configuration )
        {
            _configuration = configuration;
        }

        // Main method.
        public void Run()
        {
            var text = _configuration ["ApiSettings:BaseUri"];
            Console.WriteLine($"My API URL is: {text}");
            Console.ReadLine();
        }
    }
}
