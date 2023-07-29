using Refit;

namespace Smarty.Net.Core.USReverseGeoApi;

// marker interface for easy dependency injection and unit test mocking
public interface IUSReverseGeoClient
{
    [Get("/lookup")]
    Task<SmartyResponse> LookupAsync(Lookup lookup);
}