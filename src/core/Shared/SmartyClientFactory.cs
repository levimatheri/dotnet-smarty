using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Smarty.Net.Core.Shared;
internal class SmartyClientFactory<TClient, TOptions> : ISmartyClientFactory<TClient>, IDisposable, IAsyncDisposable
{
    private readonly Dictionary<string, ClientRegistration<TClient>> _clientRegistrations;

    private readonly IServiceProvider _serviceProvider;
    private readonly IOptionsMonitor<SmartyClientsGlobalOptions> _globalOptions;
    //private readonly IOptionsMonitor<SmartyClientCredentialOptions<TClient>> _clientsOptions;
    private readonly IOptionsMonitor<TOptions> _monitor;

    private volatile bool _disposed;

    public SmartyClientFactory(
        IServiceProvider serviceProvider,
        IOptionsMonitor<SmartyClientsGlobalOptions> globalOptions,
        //IOptionsMonitor<SmartyClientCredentialOptions<TClient>> clientsOptions,
        IEnumerable<ClientRegistration<TClient>> clientRegistrations,
        IOptionsMonitor<TOptions> monitor)
    {
        _clientRegistrations = new Dictionary<string, ClientRegistration<TClient>>();

        foreach (var registration in clientRegistrations)
        {
            _clientRegistrations[registration.Name] = registration;
        }

        _serviceProvider = serviceProvider;
        _globalOptions = globalOptions;
        _monitor = monitor;
    }

    public TClient CreateClient(string name, IHttpClientBuilder httpClientBuilder)
    {
        if (!_clientRegistrations.TryGetValue(name, out ClientRegistration<TClient> registration))
        {
            throw new InvalidOperationException($"Unable to find client registration with type '{typeof(TClient).Name}' and name '{name}'.");
        }

        //return registration.GetClient(_monitor.Get(name), httpClientBuilder, _serviceProvider);
        return registration.GetClient(_serviceProvider);
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;

            foreach (var registration in _clientRegistrations.Values)
            {
                registration.Dispose();
            }
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            _disposed = true;

            var disposeTasks = new List<Task>(_clientRegistrations.Values.Count);

            foreach (var registration in _clientRegistrations.Values)
            {
                disposeTasks.Add(registration.DisposeAsync().AsTask());
            }

            await Task.WhenAll(disposeTasks).ConfigureAwait(false);
        }
    }
}
