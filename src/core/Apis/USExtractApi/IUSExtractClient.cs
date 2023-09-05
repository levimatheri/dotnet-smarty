using Refit;

namespace Smarty.Net.Core.Apis.USExtractApi;


public interface IUSExtractClient
{
    [Post("/")]
    Task<Result> ExtractAsync([Body] string text, Lookup lookup);
}