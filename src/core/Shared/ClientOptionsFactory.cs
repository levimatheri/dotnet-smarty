using Microsoft.Extensions.Options;

namespace Smarty.Net.Core.Shared;
internal class ClientOptionsFactory<TClient, TOptions> : IClientOptionsFactory where TOptions : class
{
    private readonly IEnumerable<IConfigureOptions<TOptions>> _setups;
    private readonly IEnumerable<IPostConfigureOptions<TOptions>> _postConfigures;

    private readonly IEnumerable<ClientRegistration<TClient>> _clientRegistrations;
    private readonly IOptions<SmartyClientsGlobalOptions> _defaultOptions;
    private readonly IServiceProvider _serviceProvider;

    public ClientOptionsFactory(
        IEnumerable<IConfigureOptions<TOptions>> setups,
        IEnumerable<IPostConfigureOptions<TOptions>> postConfigures,
        IEnumerable<ClientRegistration<TClient>> clientRegistrations,
        IOptions<SmartyClientsGlobalOptions> defaultOptions,
        IServiceProvider serviceProvider)
    {
        _setups = setups;
        _postConfigures = postConfigures;
        _clientRegistrations = clientRegistrations;
        _defaultOptions = defaultOptions;
        _serviceProvider = serviceProvider;
    }

    private TOptions CreateOptions(string name)
    {
        object version = null;

        foreach (var clientRegistration in _clientRegistrations)
        {
            if (clientRegistration.Name == name)
            {
                version = clientRegistration.Version;
            }
        }

        var options = (TOptions)ClientFactory.CreateClientOptions(version, typeof(TOptions));

        if (options is ClientOptions clientOptions)
        {
            foreach (var globalConfigureOption in _defaultOptions.Value.ConfigureOptionDelegates)
            {
                globalConfigureOption(clientOptions, _serviceProvider);
            }
        }

        return options;
    }

    /// <summary>
    /// Returns a configured <typeparamref name="TOptions"/> instance with the given <paramref name="name"/>.
    /// </summary>
    public TOptions Create(string name)
    {
        var options = CreateOptions(name);
        foreach (var setup in _setups)
        {
            if (setup is IConfigureNamedOptions<TOptions> namedSetup)
            {
                namedSetup.Configure(name, options);
            }
            else if (name == Microsoft.Extensions.Options.Options.DefaultName)
            {
                setup.Configure(options);
            }
        }
        foreach (var post in _postConfigures)
        {
            post.PostConfigure(name, options);
        }

        return options;
    }

    object IClientOptionsFactory.CreateOptions(string name)
    {
        return Create(name);
    }
}
