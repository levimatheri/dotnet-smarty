using core.Shared;
using Microsoft.Extensions.Logging;
using Smarty.Net.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Smarty.Net.Core.Shared.Credentials;
internal class SharedCredentialHandler : CredentialHandler<SharedCredential>
{
    private readonly ILogger<SharedCredentialHandler> _logger;

    public SharedCredentialHandler(
        ILogger<SharedCredentialHandler> logger)
    {
        _logger = logger;
    }

    public override SharedCredential Credential { get; set; }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.RequestUri is null)
        {
            _logger.LogWarning("Request uri is null");
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        if (Credential.Id is null || Credential.HostName is null)
        {
            _logger.LogWarning("Id or Host name is null");
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        try
        {
            Utilities.AddQueryParams(request, new  Dictionary<string, string>
            {
                { "key", Credential.Id },
            });
        }
        catch (MalformedRequestParametersException mex)
        {
            _logger.LogError(mex, "Malformed request parameters");
            return await base.SendAsync(request, cancellationToken);
        }

        request.Headers.Add(HttpRequestHeader.Referer.ToString(), $"https://{Credential.HostName}");

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
