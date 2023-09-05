namespace Smarty.Net.Core.Shared;

internal abstract class CredentialHandler<TCredential> : DelegatingHandler
    where TCredential : ICredential
{
    public abstract TCredential Credential { get; set; }
}
