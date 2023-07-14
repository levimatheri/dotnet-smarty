using Refit;
using Smarty.Net.Core.USZipCodeApi;

namespace core;

public interface IUSZipCodeClient
{
    [Get("/lookup")]
    Task<IReadOnlyList<Result>> GetResultsAsync(Lookup lookup);
}
