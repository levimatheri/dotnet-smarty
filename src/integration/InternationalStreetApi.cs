using Microsoft.Extensions.Logging;
using Refit;
using Smarty.Net.Core.Apis.InternationalStreetApi;
using Candidate = Smarty.Net.Core.Apis.InternationalStreetApi.Candidate;
using Lookup = Smarty.Net.Core.Apis.InternationalStreetApi.Lookup;

namespace integration;
public class InternationalStreetApi : ISmartyApi
{
    private readonly HttpClient _httpClient;
    private readonly IInternationalStreetClient _internationalStreetsClient;
    private readonly ILogger<InternationalStreetApi> _logger;

    public InternationalStreetApi(ILogger<InternationalStreetApi> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("InternationalStreetApi");
        _internationalStreetsClient = RestService.For<IInternationalStreetClient>(_httpClient);
        _logger = logger;
    }

    private Task<IReadOnlyList<Candidate>> VerifyAsync(Lookup lookup)
        => _internationalStreetsClient.VerifyAsync(lookup);

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Running {nameof(VerifyAsync)}");

        var lookup = new Lookup
        {
            Address1 = "Rua Padre Antonio D'Angelo 121",
            Address2 = "Casa Verde",
            Locality = "Sao Paulo",
            AdministrativeArea = "SP",
            PostalCode = "02516-040",
            Country = "Brazil"
        };

        await VerifyAsync(lookup);

        _logger.LogInformation($"Finished running {nameof(VerifyAsync)}");
    }
}
