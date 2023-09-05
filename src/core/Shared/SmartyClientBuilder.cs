using Microsoft.Extensions.DependencyInjection;

namespace Smarty.Net.Core.Shared;
internal sealed class SmartyClientBuilder<TClient, TOptions> : ISmartyClientBuilder<TClient, TOptions>
    where TClient : class
    where TOptions : class
{

    internal SmartyClientBuilder(ClientRegistration<TClient> clientRegistration, IServiceCollection serviceCollection)
    {
        Registration = clientRegistration;
        ServiceCollection = serviceCollection;
    }

    public IServiceCollection ServiceCollection { get; }

    public ClientRegistration<TClient> Registration { get; }
}
