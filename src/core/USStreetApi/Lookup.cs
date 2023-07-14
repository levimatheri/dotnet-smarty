using System.Runtime.Serialization;
using Refit;
using Smarty.Net.Core.Shared;

namespace Smarty.Net.Core.USStreetApi;

public class Lookup : ILookup
{   
    [AliasAs("input_id")]
    public string? InputId { get; set; }

    [AliasAs("street")]
    public string? Street { get; set; }

    [AliasAs("street2")]
    public string? Street2 { get; set; }

    [AliasAs("secondary")]
    public string? Secondary { get; set; }

    [AliasAs("city")]
    public string? City { get; set; }

    [AliasAs("state")]
    public string? State { get; set; }

    [AliasAs("zipcode")]
    public string? ZipCode { get; set; }

    [AliasAs("lastline")]
    public string? Lastline { get; set; }

    [AliasAs("addressee")]
    public string? Addressee { get; set; }

    [AliasAs("urbanization")]
    public string? Urbanization { get; set; }

    [AliasAs("candidates")]
    public int MaxCandidates { get; set; } = 1;

    [AliasAs("match")]
    public MatchStrategy Match { get; set; } = MatchStrategy.STRICT;

    public enum MatchStrategy
    {
        [EnumMember(Value = "strict")]
        STRICT = 1,

        [EnumMember(Value = "enhanced")]
        ENHANCED = 2,

        [EnumMember(Value = "invalid")]
        INVALID = 3
    }
}
