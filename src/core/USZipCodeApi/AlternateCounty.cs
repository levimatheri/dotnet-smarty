using System.Text.Json.Serialization;

namespace Smarty.Net.Core.USZipCodeApi;

public class AlternateCounty
{
    [JsonPropertyName("county_fips")]
    public string? CountyFips { get; set; }

    [JsonPropertyName("county_name")]
    public string? CountyName { get; set; }

    [JsonPropertyName("state_abbreviation")]
    public string? StateAbbreviation { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }
}
