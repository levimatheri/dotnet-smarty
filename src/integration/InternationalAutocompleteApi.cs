using Microsoft.Extensions.Logging;
using Refit;
using Smarty.Net.Core.InternationalAutocompleteApi;
using Lookup = Smarty.Net.Core.InternationalAutocompleteApi.Lookup;

namespace integration;
public class InternationalAutocompleteApi : ISmartyApi
{
    private readonly HttpClient _httpClient;
    private readonly IInternationalAutoCompleteClient _internationalAutocompleteClient;
    private readonly ILogger<InternationalAutocompleteApi> _logger;

    public InternationalAutocompleteApi(ILogger<InternationalAutocompleteApi> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("InternationalAutocompleteApi");
        _internationalAutocompleteClient = RestService.For<IInternationalAutoCompleteClient>(_httpClient);
        _logger = logger;
    }

    private Task<Result> LookupAsync(Lookup lookup)
        => _internationalAutocompleteClient.LookupAsync(lookup);

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        // search=Louis&country=FRA&include_only_locality=Paris
        _logger.LogInformation($"Running {nameof(LookupAsync)}");

        var lookup = new Lookup
        {
            Search = "Louis",
            Country = "FRA",
            Locality = "Paris"
        };

        await LookupAsync(lookup);

        _logger.LogInformation($"Finished running {nameof(LookupAsync)}");
    }
}
