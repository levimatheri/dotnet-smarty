using Microsoft.Extensions.Logging;
using Refit;
using Smarty.Net.Core.USReverseGeoApi;

namespace integration;

public class USReverseGeoApi : ISmartyApi
{
    private readonly HttpClient _httpClient;
    private readonly IUSReverseGeoClient _usReverseGeoClient;
    private readonly ILogger<USReverseGeoApi> _logger;

    public USReverseGeoApi(ILogger<USReverseGeoApi> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ReverseGeoApi");
        _usReverseGeoClient = RestService.For<IUSReverseGeoClient>(_httpClient);
        _logger = logger;
    }

    private Task<SmartyResponse> LookupAsync(Lookup lookup)
        => _usReverseGeoClient.LookupAsync(lookup);

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Running {nameof(LookupAsync)}");

        var lookup = new Lookup
        {
            Latitude = 40.202605,
            Longitude = -111.621959
        };

        await LookupAsync(lookup);

        _logger.LogInformation($"Finished running {nameof(LookupAsync)}");
    }
}
