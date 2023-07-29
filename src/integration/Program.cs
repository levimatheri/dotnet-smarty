using integration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Serilog;

Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Verbose()
                .CreateLogger();

IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((services) =>
                {
                    services.AddTransient<ISmartyApi, USStreetApi>();
                    services.AddTransient<ISmartyApi, USZipCodeApi>();
                    services.AddTransient<ISmartyApi, USReverseGeoApi>();
                    services.AddTransient<ISmartyApi, USExtractApi>();
                    services.AddTransient<ISmartyApi, USAutocompleteProApi>();
                    services.AddTransient<ISmartyApi, InternationalStreetApi>();
                    services.AddTransient<ISmartyApi, InternationalAutocompleteApi>();

                    services.AddTransient<HttpClientDiagnosticsHandler>();
                    services.AddTransient(serviceProvider =>
                    {
                        return new AuthParamsHandler(serviceProvider.GetRequiredService<ILogger<AuthParamsHandler>>())
                        {
                            AuthId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID"),
                            AuthToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
                        };
                    });

                    services.AddHttpClient("StreetApi", options =>
                    {
                        options.BaseAddress = new Uri("https://us-street.api.smartystreets.com");
                    });

                    services.AddHttpClient("ZipCodeApi", options =>
                    {
                        options.BaseAddress = new Uri("https://us-zipcode.api.smartystreets.com");
                    });

                    services.AddHttpClient("ReverseGeoApi", options =>
                    {
                        options.BaseAddress = new Uri("https://us-reverse-geo.api.smarty.com");
                    });

                    services.AddHttpClient("ExtractApi", options =>
                    {
                        options.BaseAddress = new Uri("https://us-extract.api.smarty.com");
                    });

                    services.AddHttpClient("AutocompleteProApi", options =>
                    {
                        options.BaseAddress = new Uri("https://us-autocomplete-pro.api.smarty.com");
                    });

                    services.AddHttpClient("InternationalStreetApi", options =>
                    {
                        options.BaseAddress = new Uri("https://international-street.api.smarty.com");
                    });

                    services.AddHttpClient("InternationalAutocompleteApi", options =>
                    {
                        options.BaseAddress = new Uri("https://international-autocomplete.api.smarty.com");
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
    try
    {
        await api.RunAsync();
    }
    catch (System.Exception ex)
    {
        Log.Logger.Error("ERROR: {ex}", ex);
    }
}

await host.RunAsync();

