using core;
using Microsoft.Extensions.Logging;
using Refit;
using Smarty.Net.Core.USZipCodeApi;

namespace integration;

public class USZipCodeApi : ISmartyApi
{
    private readonly HttpClient _httpClient;
    private readonly IUSZipCodeClient _usZipCodeClient;
    private readonly ILogger<USZipCodeApi> _logger;

    public USZipCodeApi(ILogger<USZipCodeApi> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ZipCodeApi");
        _usZipCodeClient = RestService.For<IUSZipCodeClient>(_httpClient);
        _logger = logger;
    }


    private  Task<IReadOnlyList<Result>> GetResultsAsync(Lookup lookup)
        => _usZipCodeClient.GetResultsAsync(lookup);

    public async Task RunAsync()
    {
        _logger.LogInformation($"Running {nameof(GetResultsAsync)}");
        var lookup = new Smarty.Net.Core.USZipCodeApi.Lookup
        {
            ZipCode = "44721"
        };
        await GetResultsAsync(lookup);
    }
}
