namespace Smarty.Net.Core.Shared;
public class StaticCredential : ICredential
{
    public string AuthId { get; }
    public string AuthToken { get; }

    public StaticCredential(string authId, string authToken)
    {
        AuthId = authId;
        AuthToken = authToken;
    }
}
