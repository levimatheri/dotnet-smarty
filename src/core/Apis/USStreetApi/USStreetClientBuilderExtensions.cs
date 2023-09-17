using Microsoft.Extensions.DependencyInjection;
using Smarty.Net.Core.Shared;
using Smarty.Net.Core.Shared.Credentials;

namespace Smarty.Net.Core.Apis.USStreetApi;

/// <summary>
/// Extension methods to add <see cref="IUSStreetClient"/> client to clients builder.
/// </summary>
public static class USStreetClientBuilderExtensions
{
    private const string DefaultEndpoint = "https://us-street.api.smartystreets.com";
    /// <summary>
    /// Registers a <see cref="IUSStreetClient"/> instance with the provided <paramref name="endpoint"/>
    /// </summary>
    public static ISmartyClientBuilder<IUSStreetClient, USStreetClientOptions> AddUSStreetClient<TBuilder, TCredential>(
        this TBuilder builder, string endpoint, TCredential credential)
        where TCredential : ICredential
        where TBuilder : ISmartyClientFactoryBuilder
    {
        return builder.RegisterClientFactory<IUSStreetClient, USStreetClientOptions>(httpClientBuilder =>
        {
            httpClientBuilder.ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(endpoint);
            })
            .AddHttpMessageHandler(sp =>
            {
                var handler = sp.GetRequiredService<CredentialHandler<TCredential>>();
                handler.Credential = credential;
                return handler;
            });
        });
    }

    /// <summary>
    /// Registers a <see cref="IUSStreetClient"/> instance with the provided <paramref name="endpoint"/>,
    /// and authentication parameters, <paramref name="authId"/> and <paramref name="authToken"/>.
    /// </summary>
    public static ISmartyClientBuilder<IUSStreetClient, USStreetClientOptions> AddUSStreetClient<TBuilder>(
        this TBuilder builder, string endpoint, string authId, string authToken)
        where TBuilder : ISmartyClientFactoryBuilder
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(authId));
        ArgumentException.ThrowIfNullOrEmpty(nameof(authToken));
        return AddUSStreetClient(builder, endpoint, new StaticCredential(authId, authToken));
    }

    /// <summary>
    /// Registers a <see cref="IUSStreetClient"/> instance with the provided <paramref name="endpoint"/>.
    /// </summary>
    public static ISmartyClientBuilder<IUSStreetClient, USStreetClientOptions> AddUSStreetClient<TBuilder>(
        this TBuilder builder, string authId, string authToken)
        where TBuilder : ISmartyClientFactoryBuilder
    {
        return AddUSStreetClient(builder, DefaultEndpoint, new StaticCredential(authId, authToken));
    }
}
