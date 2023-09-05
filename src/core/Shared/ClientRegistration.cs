using Microsoft.Extensions.DependencyInjection;
using System.Runtime.ExceptionServices;

namespace Smarty.Net.Core.Shared;
internal class ClientRegistration<TClient> : IDisposable, IAsyncDisposable
{
    public string Name { get; set; }
    public object Version { get; set; }
    public bool RequiresTokenCredential { get; set; }

    private readonly Func<IServiceProvider, TClient> _factory;

    private readonly object _cacheLock = new object();
    private readonly bool _asyncDisposable;
    private readonly bool _disposable;

    private bool _clientInitialized;
    private TClient _cachedClient;
    private ExceptionDispatchInfo _cachedException;

    public ClientRegistration(string name, Func<IServiceProvider, TClient> factory)
    {
        Name = name;
        _factory = factory;

        _asyncDisposable = typeof(IAsyncDisposable).IsAssignableFrom(typeof(TClient));
        _disposable = typeof(IDisposable).IsAssignableFrom(typeof(TClient));
    }

    public TClient GetClient(IServiceProvider serviceProvider)
    {
        _cachedException?.Throw();

        if (_clientInitialized)
        {
            return _cachedClient;
        }

        lock (_cacheLock)
        {
            _cachedException?.Throw();

            if (_clientInitialized)
            {
                return _cachedClient;
            }

            //if (RequiresTokenCredential && tokenCredential == null)
            //{
            //    throw new InvalidOperationException("Client registration requires a TokenCredential. Configure it using UseCredential method.");
            //}

            try
            {
                _cachedClient = _factory(serviceProvider);
                _clientInitialized = true;
            }
            catch (Exception e)
            {
                _cachedException = ExceptionDispatchInfo.Capture(e);
                throw;
            }

            return _cachedClient;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_clientInitialized)
        {
            if (_asyncDisposable)
            {
                IAsyncDisposable disposableClient;

                lock (_cacheLock)
                {
                    if (!_clientInitialized)
                    {
                        return;
                    }

                    disposableClient = (IAsyncDisposable)_cachedClient;

                    _cachedClient = default;
                    _clientInitialized = false;
                }

                await disposableClient.DisposeAsync().ConfigureAwait(false);
            }
            else if (_disposable)
            {
                Dispose();
            }
        }
    }

    public void Dispose()
    {
        if (_clientInitialized)
        {
            if (_disposable)
            {
                IDisposable disposableClient;

                lock (_cacheLock)
                {
                    if (!_clientInitialized)
                    {
                        return;
                    }

                    disposableClient = (IDisposable)_cachedClient;

                    _cachedClient = default;
                    _clientInitialized = false;
                }

                disposableClient.Dispose();
            }
            else if (_asyncDisposable)
            {
                DisposeAsync().GetAwaiter().GetResult();
            }
        }
    }
}