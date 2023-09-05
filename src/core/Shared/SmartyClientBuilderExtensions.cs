using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Smarty.Net.Core.Shared;
public static class SmartyClientBuilderExtensions
{
    /// <summary>
    /// Adds a delegate to configure the client options. All delegates are executed in order they were added.
    /// </summary>
    /// <typeparam name="TClient">The type of the client.</typeparam>
    /// <typeparam name="TOptions">The options type the client uses.</typeparam>
    /// <param name="builder">The client builder instance.</param>
    /// <param name="configureOptions">The delegate to use to configure options.</param>
    /// <returns>The client builder instance.</returns>
    public static ISmartyClientBuilder<TClient, TOptions> ConfigureOptions<TClient, TOptions>(this ISmartyClientBuilder<TClient, TOptions> builder, Action<TOptions> configureOptions)
        where TClient : class
        where TOptions : class
    {
        return builder.ConfigureOptions((options, _) => configureOptions(options));
    }

    /// <summary>
    /// Configures client options using provided <see cref="IConfiguration"/> instance.
    /// </summary>
    /// <typeparam name="TClient">The type of the client.</typeparam>
    /// <typeparam name="TOptions">The options type the client uses.</typeparam>
    /// <param name="builder">The client builder instance.</param>
    /// <param name="configuration">The configuration instance to use.</param>
    /// <returns>The client builder instance.</returns>
    public static ISmartyClientBuilder<TClient, TOptions> ConfigureOptions<TClient, TOptions>(this ISmartyClientBuilder<TClient, TOptions> builder, IConfiguration configuration)
        where TClient : class
        where TOptions : class
    {
        return builder.ConfigureOptions(options => configuration.Bind(options));
    }

    /// <summary>
    /// Adds a delegate to configure the client options. All delegates are executed in order they were added.
    /// </summary>
    /// <typeparam name="TClient">The type of the client.</typeparam>
    /// <typeparam name="TOptions">The options type the client uses.</typeparam>
    /// <param name="builder">The client builder instance.</param>
    /// <param name="configureOptions">The delegate to use to configure options.</param>
    /// <returns>The client builder instance.</returns>
    public static ISmartyClientBuilder<TClient, TOptions> ConfigureOptions<TClient, TOptions>(this ISmartyClientBuilder<TClient, TOptions> builder, Action<TOptions, IServiceProvider> configureOptions)
        where TClient : class
        where TOptions : class
    {
        var impl = builder.ToBuilder();
        impl.ServiceCollection.AddSingleton<IConfigureOptions<TOptions>>(provider => new ConfigureClientOptions<TClient, TOptions>(provider, impl.Registration, configureOptions)); ;
        return builder;
    }

    /// <summary>
    /// Set the credential to use for this client registration.
    /// </summary>
    /// <typeparam name="TClient">The type of the client.</typeparam>
    /// <typeparam name="TOptions">The options type the client uses.</typeparam>
    /// <param name="builder">The client builder instance.</param>
    /// <param name="credential">The credential to use.</param>
    /// <returns>The client builder instance.</returns>
    public static ISmartyClientBuilder<TClient, TOptions> WithCredential<TClient, TOptions>(this ISmartyClientBuilder<TClient, TOptions> builder, ICredential credential)
        where TClient : class
        where TOptions : class
    {
        return builder.WithCredential(_ => credential);
    }

    /// <summary>
    /// Set the credential factory to use for this client registration.
    /// </summary>
    /// <typeparam name="TClient">The type of the client.</typeparam>
    /// <typeparam name="TOptions">The options type the client uses.</typeparam>
    /// <param name="builder">The client builder instance.</param>
    /// <param name="credentialFactory">The credential factory to use.</param>
    /// <returns>The client builder instance.</returns>
    public static ISmartyClientBuilder<TClient, TOptions> WithCredential<TClient, TOptions>(this ISmartyClientBuilder<TClient, TOptions> builder, Func<IServiceProvider, ICredential> credentialFactory)
        where TClient : class
        where TOptions : class
    {
        var impl = builder.ToBuilder();
        impl.ServiceCollection.AddSingleton<IConfigureOptions<SmartyClientCredentialOptions<TClient>>>(new ConfigureClientCredentials<TClient, TOptions>(impl.Registration, credentialFactory));
        return builder;
    }

    private static SmartyClientBuilder<TClient, TOptions> ToBuilder<TClient, TOptions>(this ISmartyClientBuilder<TClient, TOptions> builder)
        where TClient : class
        where TOptions : class
    {
        return (SmartyClientBuilder<TClient, TOptions>)builder;
    }
}
