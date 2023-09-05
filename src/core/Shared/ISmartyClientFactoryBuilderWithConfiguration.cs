namespace Smarty.Net.Core.Shared;
public interface ISmartyClientFactoryBuilderWithConfiguration<in TConfiguration> : ISmartyClientFactoryBuilder
{
    /// <summary>
    /// Registers a client in the dependency injection container using the configuration to create a client instance.
    /// </summary>
    /// <typeparam name="TClient">The type of the client.</typeparam>
    /// <typeparam name="TOptions">The client options type used the client.</typeparam>
    /// <param name="configuration">Instance of <typeparamref name="TConfiguration"/> to use.</param>
    /// <returns><see cref="ISmartyClientBuilder{TClient,TOptions}"/> that allows customizing the client registration.</returns>
    ISmartyClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(TConfiguration configuration)
        where TClient : class
        where TOptions : class;
}
