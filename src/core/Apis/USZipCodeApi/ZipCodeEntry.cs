using System.Text.Json.Serialization;

namespace Smarty.Net.Core.Apis.USZipCodeApi;

public class ZipCodeEntry
{
    [JsonPropertyName("zipcode")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("zipcode_type")]
    public string? ZipCodeType { get; set; }

    [JsonPropertyName("default_city")]
    public string? DefaultCity { get; set; }

    [JsonPropertyName("county_fips")]
    public string? CountyFips { get; set; }

    [JsonPropertyName("county_name")]
    public string? CountyName { get; set; }

    [JsonPropertyName("state_abbreviation")]
    public string? StateAbbreviation { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("precision")]
    public string? Precision { get; set; }

    [JsonPropertyName("alternate_counties")]
    public IEnumerable<AlternateCounty> AlternateCounties { get; set; } = Enumerable.Empty<AlternateCounty>();

}