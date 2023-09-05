using Refit;
using Smarty.Net.Core.Apis.Shared;

namespace Smarty.Net.Core.Apis.USZipCodeApi;

public class Lookup : ILookup
{
    [AliasAs("input_id")]
    public string? InputId { get; set; }

    [AliasAs("city")]
    public string? City { get; set; }

    [AliasAs("state")]
    public string? State { get; set; }

    [AliasAs("zipcode")]
    public string? ZipCode { get; set; }
}
