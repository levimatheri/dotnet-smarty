using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace integration;

public class HttpClientDiagnosticsHandler : DelegatingHandler
{
    private readonly ILogger<HttpClientDiagnosticsHandler> _logger;

    public HttpClientDiagnosticsHandler(ILogger<HttpClientDiagnosticsHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var totalElapsedTime = Stopwatch.StartNew();

        _logger.LogDebug("Request: {request}", request);
        if (request.Content != null)
        {
            var content = await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            _logger.LogDebug("Request Content: {content}", content);
        }

        var responseElapsedTime = Stopwatch.StartNew();
        var response = await base.SendAsync(request, cancellationToken);

        _logger.LogDebug("Response: {response}", response);
        if (response.Content != null)
        {
            var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            _logger.LogDebug("Response Content: {content}", content);
        }

        responseElapsedTime.Stop();
        _logger.LogDebug("Response elapsed time: {elapsedTime} ms", responseElapsedTime.ElapsedMilliseconds);

        totalElapsedTime.Stop();
        _logger.LogDebug("Total elapsed time: {elapsedTime} ms", totalElapsedTime.ElapsedMilliseconds);

        return response;
    }
}
