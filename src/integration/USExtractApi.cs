using Microsoft.Extensions.Logging;
using Refit;
using Smarty.Net.Core.USExtractApi;

namespace integration;

public class USExtractApi : ISmartyApi
{
    private readonly HttpClient _httpClient;
    private readonly IUSExtractClient _usExtractClient;
    private readonly ILogger<USExtractApi> _logger;

    public USExtractApi(ILogger<USExtractApi> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ExtractApi");
        _usExtractClient = RestService.For<IUSExtractClient>(_httpClient);
        _logger = logger;
    }

    private Task<Result> ExtractAsync(string text, Lookup lookup)
        => _usExtractClient.ExtractAsync(text, lookup);

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Running {nameof(ExtractAsync)}");

        var lookup = new Lookup
        {
            IsAggressive = true
        };

        var text = "There are addresses everywhere. 1109 Ninth 85007 Smarty can find them. 3785 Las Vegs Av. Los Vegas, Nevada That is all.";

        await ExtractAsync(text, lookup);

        _logger.LogInformation($"Finished running {nameof(ExtractAsync)}");
    }
}
