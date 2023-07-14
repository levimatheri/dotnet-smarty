using Refit;
using Serilog;
using Smarty.Net.Core.USStreetApi;

namespace TestApp;

public class USStreetsApi
{
    private readonly HttpClient _httpClient;
    private readonly IUSStreetClient _usStreetsClient;
    public USStreetsApi(Uri baseUrl, ILogger logger, string authId, string authToken)
    {
        _httpClient = new HttpClient(new HttpClientDiagnosticsHandler(new AuthParamsHandler(logger) { AuthId = authId, AuthToken = authToken })) { BaseAddress = baseUrl };
        _usStreetsClient = RestService.For<IUSStreetClient>(_httpClient);
    }

    public Task<IReadOnlyList<Candidate>> GetCandidatesAsync(Lookup lookup)
        => _usStreetsClient.GetCandidatesAsync(lookup);

    public Task<IReadOnlyList<Candidate>> GetCandidatesBatchAsync(Batch batch)
        => _usStreetsClient.GetCandidatesBatchAsync(batch);
}
