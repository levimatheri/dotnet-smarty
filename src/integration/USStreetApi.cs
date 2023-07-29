using Microsoft.Extensions.Logging;
using Refit;
using Smarty.Net.Core.USStreetApi;

namespace integration;

public class USStreetApi : ISmartyApi
{
    private readonly HttpClient _httpClient;
    private readonly IUSStreetClient _usStreetsClient;
    private readonly ILogger<USStreetApi> _logger;

    public USStreetApi(ILogger<USStreetApi> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("StreetApi");
        _usStreetsClient = RestService.For<IUSStreetClient>(_httpClient);
        _logger = logger;
    }

    private Task<IReadOnlyList<Candidate>> GetCandidatesAsync(Lookup lookup, CancellationToken cancellationToken)
        => _usStreetsClient.GetCandidatesAsync(lookup, cancellationToken);

    private Task<IReadOnlyList<Candidate>> GetCandidatesBatchAsync(Batch batch, CancellationToken cancellationToken)
        => _usStreetsClient.GetCandidatesBatchAsync(batch, cancellationToken);

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Running {nameof(GetCandidatesAsync)}");

        var lookup = new Lookup
        {
            Street = "1600 Amphitheatre Pkwy",
            City = "Mountain View",
            State = "CA",
            MaxCandidates = 10
        };

        await GetCandidatesAsync(lookup, cancellationToken);

        _logger.LogInformation($"Finished running {nameof(GetCandidatesAsync)}");

        _logger.LogInformation($"Running {nameof(GetCandidatesBatchAsync)}");

        var batch = new Batch
        {
            new Lookup
            {
                Street = "1600 Amphitheatre Pkwy",
                City = "Mountain View",
                State = "CA",
                MaxCandidates = 10
            },
            new Lookup
            {
                Street = "2600 Cleveland Ave",
                City = "Canton",
                State = "OH",
                MaxCandidates = 10
            }
        };

        await GetCandidatesBatchAsync(batch, cancellationToken);

        _logger.LogInformation($"Finished running {nameof(GetCandidatesBatchAsync)}");
    }
}
