using Microsoft.Extensions.Logging;
using Refit;
using Smarty.Net.Core.Apis.InternationalAutocompleteApi;
using Lookup = Smarty.Net.Core.Apis.InternationalAutocompleteApi.Lookup;

namespace integration;
public class InternationalAutocompleteApi : ISmartyApi
{
    private readonly HttpClient _httpClient;
    private readonly IInternationalAutocompleteClient _internationalAutocompleteClient;
    private readonly ILogger<InternationalAutocompleteApi> _logger;

    public InternationalAutocompleteApi(ILogger<InternationalAutocompleteApi> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("InternationalAutocompleteApi");
        _internationalAutocompleteClient = RestService.For<IInternationalAutocompleteClient>(_httpClient);
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
