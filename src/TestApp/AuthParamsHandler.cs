using System.Net.Http;
using Serilog;

namespace TestApp;


public class AuthParamsHandler : DelegatingHandler
{
    private readonly Serilog.ILogger _logger;

    public string AuthId { get; set; }
    public string AuthToken { get; set; }

    public AuthParamsHandler(ILogger logger)
    {
        _logger = logger;
        InnerHandler = new HttpClientHandler();
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.RequestUri is null)
        {
            _logger.Warning("Request uri is null");
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        var requestQuery = request.RequestUri.Query;
        var paramParts = requestQuery.TrimStart('?').Split("&");
        var existingParams = new Dictionary<string, string>();

        foreach (var paramPart in paramParts)
        {
            if (!string.IsNullOrEmpty(paramPart))
            {
                var paramVals = paramPart.Split('=');
                if (paramVals.Length == 0)
                {
                    _logger.Error("Request params not well-formed. Request: {requestUri}", request.RequestUri);
                    return await base.SendAsync(request, cancellationToken);
                }

                existingParams[paramVals[0]] = paramVals[1];
            }
        }
                
        existingParams["auth-id"] = AuthId;
        existingParams["auth-token"] = AuthToken;

        var newQueryParamString = string.Join("&", existingParams.Select(x => $"{x.Key}={x.Value}"));
        var newRequestQuery = $"?{newQueryParamString}";

        var uriBuilder = new UriBuilder(request.RequestUri)
        {
            Query = newRequestQuery
        };

        request.RequestUri = uriBuilder.Uri;

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }

}
