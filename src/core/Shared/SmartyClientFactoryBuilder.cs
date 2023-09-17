using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Refit;
using Smarty.Net.Core.Shared.Credentials;

namespace Smarty.Net.Core.Shared;
public sealed class SmartyClientFactoryBuilder : ISmartyClientFactoryBuilder
{
    private readonly IServiceCollection _serviceCollection;

    internal const string DefaultClientName = "Default";

    internal SmartyClientFactoryBuilder(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    /// <summary>
    /// Adds a configuration delegate that gets executed for all clients.
    /// </summary>
    /// <param name="configureOptions">The configuration delegate.</param>
    /// <returns>This instance.</returns>
    public SmartyClientFactoryBuilder ConfigureDefaults(Action<ClientOptions> configureOptions)
    {
        ConfigureDefaults((options, provider) => configureOptions(options));
        return this;
    }

    /// <summary>
    /// Adds a configuration delegate that gets executed for all clients.
    /// </summary>
    /// <param name="configureOptions">The configuration delegate.</param>
    /// <returns>This instance.</returns>
    public SmartyClientFactoryBuilder ConfigureDefaults(Action<ClientOptions, IServiceProvider> configureOptions)
    {
        _serviceCollection.Configure<SmartyClientsGlobalOptions>(options => options.ConfigureOptionDelegates.Add(configureOptions));

        return this;
    }

    /// <summary>
    /// Adds a configuration instance to initialize all clients from.
    /// </summary>
    /// <param name="configuration">The configuration instance.</param>
    /// <returns>This instance.</returns>
    public SmartyClientFactoryBuilder ConfigureDefaults(IConfiguration configuration)
    {
        ConfigureDefaults(options => configuration.Bind(options));

        //var credentialsFromConfig = ClientFactory.CreateCredential(configuration);

        //if (credentialsFromConfig != null)
        //{
        //    UseCredential(credentialsFromConfig);
        //}

        return this;
    }

    //ISmartyClientBuilder<TClient, TOptions> ISmartyClientFactoryBuilder.RegisterClientFactory<TClient, TOptions>(Func<TOptions, IHttpClientBuilder, IServiceProvider, TClient> clientFactory)
    //{
    //    throw new NotImplementedException();
    //}

    //ISmartyClientBuilder<TClient, TOptions> ISmartyClientFactoryBuilderWithConfiguration<IConfiguration>.RegisterClientFactory<TClient, TOptions>(IConfiguration configuration)
    //{
    //    // var credentialsFromConfig = ClientFactory.CreateCredential(configuration);
    //    var clientBuilder = ((ISmartyClientFactoryBuilder)this).RegisterClientFactory<TClient, TOptions>(
    //                        (options, httpClientBuilder, provider) => (TClient)ClientFactory.CreateClient(typeof(TClient), typeof(TOptions), options, configuration))
    //                    .ConfigureOptions(configuration);

    //    return clientBuilder;
    //}

    ISmartyClientBuilder<TClient, TOptions> ISmartyClientFactoryBuilder.RegisterClientFactory<TClient, TOptions>(Action<IHttpClientBuilder> clientBuilderConfig)
        where TClient : class
        where TOptions : class
    {
        clientBuilderConfig(_serviceCollection.AddRefitClient<TClient>());
        var clientRegistration = new ClientRegistration<TClient>(DefaultClientName, provider => provider.GetRequiredService<TClient>());
        //{
        //    RequiresTokenCredential = requiresCredential
        //};

        //_serviceCollection.AddSingleton(clientRegistration);

        //_serviceCollection.TryAddSingleton(typeof(IConfigureOptions<AzureClientCredentialOptions<TClient>>), typeof(DefaultCredentialClientOptionsSetup<TClient>));
        _serviceCollection.TryAddSingleton(typeof(IOptionsMonitor<TOptions>), typeof(ClientOptionsMonitor<TClient, TOptions>));
        _serviceCollection.TryAddSingleton(typeof(ClientOptionsFactory<TClient, TOptions>), typeof(ClientOptionsFactory<TClient, TOptions>));
        _serviceCollection.TryAddSingleton(typeof(ISmartyClientFactory<TClient>), typeof(SmartyClientFactory<TClient, TOptions>));
        _serviceCollection.AddTransient<ICredential, StaticCredential>();
        _serviceCollection.AddTransient(typeof(CredentialHandler<StaticCredential>), typeof(StaticCredentialHandler));
        //_serviceCollection.AddSingleton(
        //    typeof(TClient),
        //    provider => provider.GetService<ISmartyClientFactory<TClient>>()
        //        .CreateClient(
        //            DefaultClientName,
        //            _serviceCollection.AddRefitClient<TClient>()));

        return new SmartyClientBuilder<TClient, TOptions>(clientRegistration, _serviceCollection);
    }
}
