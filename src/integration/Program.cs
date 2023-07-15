using integration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;

Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Verbose()
                .CreateLogger();

IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services => {
                    services.AddTransient<ISmartyApi, USStreetsApi>();
                    services.AddTransient<ISmartyApi, USZipCodeApi>();

                    const string authId = "f7b6ef9b-8a3f-4f23-956d-788d714162c3";
                    const string authToken = "YagchQwvTGhELfjdvXyz";

                    services.AddTransient<HttpClientDiagnosticsHandler>();
                    services.AddTransient((serviceProvider) => {
                        return new AuthParamsHandler(serviceProvider.GetRequiredService<ILogger<AuthParamsHandler>>())
                        {
                            AuthId = authId,
                            AuthToken = authToken
                        };
                    });

                    services.AddHttpClient("StreetsApi", options => {
                        options.BaseAddress = new Uri("https://us-street.api.smartystreets.com");
                    });
                    
                    services.AddHttpClient("ZipCodeApi", options => {
                        options.BaseAddress = new Uri("https://us-zipcode.api.smartystreets.com");
                    });

                    services.ConfigureAll<HttpClientFactoryOptions>(options =>
                    {
                        options.HttpMessageHandlerBuilderActions.Add(builder =>
                        {
                            builder.AdditionalHandlers.Add(builder.Services.GetRequiredService<AuthParamsHandler>());
                            builder.AdditionalHandlers.Add(builder.Services.GetRequiredService<HttpClientDiagnosticsHandler>());
                        });
                    });
                })
                .UseSerilog()
                .Build();
        
var apis = host.Services.GetRequiredService<IEnumerable<ISmartyApi>>();

foreach (var api in apis)
{
    await api.RunAsync();
}

await host.RunAsync();

