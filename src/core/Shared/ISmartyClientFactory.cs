using Microsoft.Extensions.DependencyInjection;

namespace Smarty.Net.Core.Shared;

internal interface ISmartyClientFactory<TClient>
{
    TClient CreateClient(string name, IHttpClientBuilder httpClientBuilder);
}