using Microsoft.Extensions.Configuration;
using Smarty.Net.Core.Shared.Credentials;

namespace Smarty.Net.Core.Shared;
internal class SmartyClientsGlobalOptions
{
    public Func<IServiceProvider, ICredential> CredentialFactory { get; set; }
    public List<Action<ClientOptions, IServiceProvider>> ConfigureOptionDelegates { get; } = new List<Action<ClientOptions, IServiceProvider>>();
    public Func<IServiceProvider, IConfiguration> ConfigurationRootResolver { get; set; }
}
