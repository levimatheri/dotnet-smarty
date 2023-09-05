using Refit;

namespace Smarty.Net.Core.Apis.USZipCodeApi;

public interface IUSZipCodeClient
{
    [Get("/lookup")]
    Task<IReadOnlyList<Result>> GetResultsAsync(Lookup lookup);
}
