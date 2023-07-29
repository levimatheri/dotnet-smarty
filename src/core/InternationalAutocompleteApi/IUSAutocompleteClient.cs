using Refit;

namespace Smarty.Net.Core.InternationalAutocompleteApi
{
    public interface IInternationalAutoCompleteClient
    {
        [Get("/lookup")]
        Task<Result> LookupAsync(Lookup lookup, CancellationToken cancellationToken = default);
    }
}