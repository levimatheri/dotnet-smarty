using Refit;

namespace Smarty.Net.Core.USExtractApi;


public interface IUSExtractClient
{
    [Post("/")]
    Task<Result> ExtractAsync([Body] string text, Lookup lookup);
}