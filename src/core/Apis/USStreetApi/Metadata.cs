using System.Text.Json.Serialization;

namespace Smarty.Net.Core.Apis.USStreetApi;

public class Metadata
{
    [JsonPropertyName("record_type")]
    public string? RecordType { get; set; }

    [JsonPropertyName("zip_type")]
    public string? ZipType { get; set; }

    [JsonPropertyName("county_fips")]
    public string? CountyFips { get; set; }

    [JsonPropertyName("county_name")]
    public string? CountyName { get; set; }

    [JsonPropertyName("carrier_route")]
    public string? CarrierRoute { get; set; }

    [JsonPropertyName("congressional_district")]
    public string? CongressionalDistrict { get; set; }

    [JsonPropertyName("building_default_indicator")]
    public string? BuildingDefaultIndicator { get; set; }

    [JsonPropertyName("rdi")]
    public string? Rdi { get; set; }

    [JsonPropertyName("elot_sequence")]
    public string? ElotSequence { get; set; }

    [JsonPropertyName("elot_sort")]
    public string? ElotSort { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("precision")]
    public string? Precision { get; set; }

    [JsonPropertyName("time_zone")]
    public string? TimeZone { get; set; }

    [JsonPropertyName("utc_offset")]
    public double UtcOffset { get; set; }

    [JsonPropertyName("dst")]
    public bool ObeysDst { get; set; }

    [JsonPropertyName("ews_match")]
    public bool IsEwsMatch { get; set; }
}