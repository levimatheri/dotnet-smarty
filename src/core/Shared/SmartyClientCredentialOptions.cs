namespace Smarty.Net.Core.Shared;
internal class SmartyClientCredentialOptions<TClient>
{
    public Func<IServiceProvider, ICredential> CredentialFactory { get; set; }
}
