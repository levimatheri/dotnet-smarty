using core;
using Refit;
using Serilog;
using Smarty.Net.Core.USZipCodeApi;

namespace TestApp;

public class USZipCodeApi
{
    private readonly HttpClient _httpClient;
    private readonly IUSZipCodeClient _usZipCodeClient;
    public USZipCodeApi(Uri baseUrl, ILogger logger, string authId, string authToken)
    {
        _httpClient = new HttpClient(new HttpClientDiagnosticsHandler(new AuthParamsHandler(logger) { AuthId = authId, AuthToken = authToken })) { BaseAddress = baseUrl };
        _usZipCodeClient = RestService.For<IUSZipCodeClient>(_httpClient);
    }


    public Task<IReadOnlyList<Result>> GetResultsAsync(Lookup lookup)
        => _usZipCodeClient.GetResultsAsync(lookup);
}
