using System.Text.Json.Serialization;

namespace Smarty.Net.Core.USZipCodeApi;

public class Result
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("input_id")]
    public string? InputId { get; set; }

    [JsonPropertyName("input_index")]
    public int InputIndex { get; set; }

    [JsonPropertyName("city_states")]
    public IEnumerable<CityEntry> CityStates { get; set; } = Enumerable.Empty<CityEntry>();

    [JsonPropertyName("zipcodes")]
    public IEnumerable<ZipCodeEntry> ZipCodes { get; set; } = Enumerable.Empty<ZipCodeEntry>();
}