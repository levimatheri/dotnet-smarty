using Refit;

namespace Smarty.Net.Core.Apis.InternationalAutocompleteApi
{
    public interface IInternationalAutocompleteClient
    {
        [Get("/lookup")]
        Task<Result> LookupAsync(Lookup lookup, CancellationToken cancellationToken = default);
    }
}