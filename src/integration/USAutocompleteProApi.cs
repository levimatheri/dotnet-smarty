using Microsoft.Extensions.Logging;
using Refit;
using SmartyStreets.USAutocompleteProApi;

namespace integration;
public class USAutocompleteProApi : ISmartyApi
{
    private readonly HttpClient _httpClient;
    private readonly IUSAutoCompleteProClient _usAutocompleteProClient;
    private readonly ILogger<USAutocompleteProApi> _logger;

    public USAutocompleteProApi(ILogger<USAutocompleteProApi> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("AutocompleteProApi");
        _usAutocompleteProClient = RestService.For<IUSAutoCompleteProClient>(_httpClient);
        _logger = logger;
    }

    private Task<Result> LookupAsync(Lookup lookup)
        => _usAutocompleteProClient.LookupAsync(lookup);

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Running {nameof(USAutocompleteProApi)}");

        var lookup = new Lookup
        {
            Search = "123 mai",
            IncludeOnlyCities = new List<string>
            {
                "Chicago,il"
            },
            IncludeOnlyStates = new List<string>
            {
                "mi"
            }
        };

        await LookupAsync(lookup);

        _logger.LogInformation($"Finished running {nameof(USAutocompleteProApi)}");
    }
}
