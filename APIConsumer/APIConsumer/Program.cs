/*******************************************************************************************
 * 
 * Auth: DRT
 * Date: 16/11/2025
 * 
 * Description: 
 * 
 * Programme entry point.
 * 
 ******************************************************************************************/

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using APIConsumer;

// Use builder to load required JSON file.
var builder = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

// Creates service collections and adds services.
ServiceCollection services = new();
services.AddSingleton<Application>();
services.AddSingleton<IConfiguration>(builder);

// Build the DI container.
var provider = services.BuildServiceProvider();

// Run main application.
var app = provider.GetRequiredService<Application>();
app.Run();

// TODO: Add API calls as a separate service.

//HttpClient httpClient = new HttpClient();

//string uri = @"https://jsonplaceholder.typicode.com/posts";

//try
//{
//    // Fetches resource and converts to string.
//    // Throws and returns error code if unsuccessful.
//    string responseBody = await httpClient.GetStringAsync(uri);

//    Console.WriteLine(responseBody);
//}
//catch(Exception e)
//{
//    Console.WriteLine("\nException Caught!");
//    Console.WriteLine("Message :{0} ", e.Message);
//}
