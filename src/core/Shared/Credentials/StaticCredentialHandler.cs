using core.Shared;
using Microsoft.Extensions.Logging;
using Smarty.Net.Core.Shared;

namespace Smarty.Net.Core.Shared.Credentials;
internal class StaticCredentialHandler : CredentialHandler<StaticCredential>
{
    private readonly ILogger<StaticCredentialHandler> _logger;

    public StaticCredentialHandler(
        ILogger<StaticCredentialHandler> logger)
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

        try
        {
            Utilities.AddQueryParams(request, new  Dictionary<string, string>
            {
                { "auth-id", Credential.AuthId },
                { "auth-token", Credential.AuthToken },
            });
        }
        catch (MalformedRequestParametersException mex)
        {
            _logger.LogError(mex, "Malformed request parameters");
            return await base.SendAsync(request, cancellationToken);
        }

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
