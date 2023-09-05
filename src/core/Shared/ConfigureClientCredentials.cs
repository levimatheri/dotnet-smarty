using Microsoft.Extensions.Options;

namespace Smarty.Net.Core.Shared;
internal class ConfigureClientCredentials<TClient, TOptions> : IConfigureNamedOptions<SmartyClientCredentialOptions<TClient>>
{
    private readonly ClientRegistration<TClient> _registration;
    private readonly Func<IServiceProvider, ICredential> _credentialFactory;

    public ConfigureClientCredentials(
        ClientRegistration<TClient> registration,
        Func<IServiceProvider, ICredential> credentialFactory)
    {
        _registration = registration;
        _credentialFactory = credentialFactory;
    }

    public void Configure(SmartyClientCredentialOptions<TClient> options)
    {
    }

    public void Configure(string name, SmartyClientCredentialOptions<TClient> options)
    {
        if (name == _registration.Name)
        {
            options.CredentialFactory = _credentialFactory;
        }
    }
}
