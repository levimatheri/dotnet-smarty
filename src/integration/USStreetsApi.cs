using Microsoft.Extensions.Logging;
using Refit;
using Smarty.Net.Core.USStreetApi;

namespace integration;

public class USStreetsApi : ISmartyApi
{
    private readonly HttpClient _httpClient;
    private readonly IUSStreetClient _usStreetsClient;
    private readonly ILogger<USStreetsApi> _logger;

    public USStreetsApi(ILogger<USStreetsApi> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("StreetsApi");
        _usStreetsClient = RestService.For<IUSStreetClient>(_httpClient);
        _logger = logger;
    }

    public Task<IReadOnlyList<Candidate>> GetCandidatesAsync(Lookup lookup)
        => _usStreetsClient.GetCandidatesAsync(lookup);

    public Task<IReadOnlyList<Candidate>> GetCandidatesBatchAsync(Batch batch)
        => _usStreetsClient.GetCandidatesBatchAsync(batch);

    public async Task RunAsync()
    {
        _logger.LogInformation($"Running {nameof(GetCandidatesAsync)}");

        var lookup = new Lookup
        {
            Street = "1600 Amphitheatre Pkwy",
            City = "Mountain View",
            State = "CA",
            MaxCandidates = 10
        };

        await GetCandidatesAsync(lookup);

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

        await GetCandidatesBatchAsync(batch);

        _logger.LogInformation($"Finished running {nameof(GetCandidatesBatchAsync)}");
    }
}
