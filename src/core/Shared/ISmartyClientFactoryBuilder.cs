using Microsoft.Extensions.DependencyInjection;

namespace Smarty.Net.Core.Shared;

/// <summary>
/// Abstraction for registering Azure clients in dependency injection containers.
/// </summary>
public interface ISmartyClientFactoryBuilder
{
    /// <summary>
    /// Registers a client in the dependency injection container using the factory to create a client instance.
    /// </summary>
    /// <typeparam name="TClient">The type of the client.</typeparam>
    /// <typeparam name="TOptions">The client options type used the client.</typeparam>
    /// <param name="clientFactory">The factory, that given the instance of options, returns a client instance.</param>
    /// <returns><see cref="ISmartyClientBuilder{TClient,TOptions}"/> that allows customizing the client registration.</returns>
    ISmartyClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(Action<IHttpClientBuilder> clientFactory)
        where TClient : class
        where TOptions : class;
}
