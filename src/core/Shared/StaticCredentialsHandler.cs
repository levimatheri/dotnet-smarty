using Microsoft.Extensions.Logging;

namespace Smarty.Net.Core.Shared;
internal class StaticCredentialsHandler : CredentialHandler<StaticCredential>
{
    private readonly ILogger<StaticCredentialsHandler> _logger;

    public StaticCredentialsHandler(
        ILogger<StaticCredentialsHandler> logger)
    {
        _logger = logger;
    }

    public override StaticCredential Credential { get; set; }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.RequestUri is null)
        {
            _logger.LogWarning("Request uri is null");
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        if (Credential.AuthId is null || Credential.AuthToken is null)
        {
            _logger.LogWarning("Auth Id or Token is null");
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
                    _logger.LogError("Request params not well-formed. Request: {requestUri}", request.RequestUri);
                    return await base.SendAsync(request, cancellationToken);
                }

                existingParams[paramVals[0]] = paramVals[1];
            }
        }

        existingParams["auth-id"] = Credential.AuthId;
        existingParams["auth-token"] = Credential.AuthToken;

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
