using Microsoft.Extensions.DependencyInjection;
using Smarty.Net.Core.Shared;
using Smarty.Net.Core.Shared.Credentials;

namespace Smarty.Net.Core.Apis.InternationalAutocompleteApi;

/// <summary>
/// Extension methods to add <see cref="IInternationalAutocompleteClient"/> client to clients builder.
/// </summary>
public static class InternationalAutocompleteClientBuilderExtensions
{
    private const string DefaultEndpoint = "https://international-autocomplete.api.smarty.com";
    /// <summary>
    /// Registers a <see cref="IInternationalAutocompleteClient"/> instance with the provided <paramref name="endpoint"/>
    /// </summary>
    public static ISmartyClientBuilder<IInternationalAutocompleteClient, InternationalAutocompleteClientOptions> AddInternationalAutocompleteClient<TBuilder, TCredential>(
        this TBuilder builder, string endpoint, TCredential credential)
        where TCredential : ICredential
        where TBuilder : ISmartyClientFactoryBuilder
    {
        return builder.RegisterClientFactory<IInternationalAutocompleteClient, InternationalAutocompleteClientOptions>(httpClientBuilder =>
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
    /// Registers a <see cref="IInternationalAutocompleteClient"/> instance with the provided <paramref name="endpoint"/>
    /// </summary>
    public static ISmartyClientBuilder<IInternationalAutocompleteClient, InternationalAutocompleteClientOptions> AddInternationalAutocompleteClient<TBuilder>(
        this TBuilder builder, string authId, string authToken)
        where TBuilder : ISmartyClientFactoryBuilder
    {
        return AddInternationalAutocompleteClient(builder, DefaultEndpoint, new StaticCredential(authId, authToken));
    }
}
