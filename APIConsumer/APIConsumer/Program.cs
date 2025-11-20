/*******************************************************************************************
 * 
 * Auth: DRT
 * Date: 16/11/2025
 * 
 * Description: Program entry point.
 * 
 * Builds a .NET Generic Host using the 'Microsoft.Extensions.Hosting' package. A 'host' is 
 * an object that encapsulates an app's resources and lifetime functionality, such as:
 * 
 * + Dependency injection (DI)
 * + Logging
 * + Configuration
 * + App shutdown
 * + IHostedService implementations
 * 
 * Requires Microsoft.Extensions.Http package to expose "AddHttpClient". 
 * 
 ******************************************************************************************/

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using APIConsumer;

// Create host builder.
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Configure host.
builder.Configuration.AddJsonFile("appsettings.json" , optional: false , reloadOnChange: true);

// Register services.
// Only want one instance of our main app.
// Use AddHttpClient to manage HttpClient instances correctly.
builder.Services.AddSingleton<Application>();
builder.Services.AddHttpClient<IApiService , ApiService>(client =>
{
    var baseUri = builder.Configuration ["ApiSettings:BaseUri"];

    if ( baseUri is null )
        throw new InvalidOperationException("ApiSettings:BaseUri is missing.");

    client.BaseAddress = new Uri(baseUri);
});

IHost host = builder.Build();

// Run main application.
Application app = host.Services.GetRequiredService<Application>();
await app.Run();
