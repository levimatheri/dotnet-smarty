using Refit;

namespace Smarty.Net.Core.Apis.InternationalStreetApi
{
    public interface IInternationalStreetClient
    {
        [Get("/verify")]
        Task<IReadOnlyList<Candidate>> VerifyAsync(Lookup lookup);
    }
}