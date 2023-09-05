using System.Text.Json.Serialization;

namespace Smarty.Net.Core.Apis.USZipCodeApi;

public class CityEntry
{
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("mailable_city")]
    public bool MailableCity { get; set; }

    [JsonPropertyName("state_abbreviation")]
    public string? StateAbbreviation { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }
}