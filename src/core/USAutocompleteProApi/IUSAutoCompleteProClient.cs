using Refit;

namespace SmartyStreets.USAutocompleteProApi
{
    public interface IUSAutoCompleteProClient
    {
        [Get("/lookup")]
        Task<Result> LookupAsync(Lookup lookup);
    }
}