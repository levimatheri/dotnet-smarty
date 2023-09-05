using System.Text.Json.Serialization;

namespace Smarty.Net.Core.Apis.USExtractApi;


/// <summary>
///     See "https://smartystreets.com/docs/cloud/us-extract-api#http-response-status"
/// </summary>
public class Result
{
    [JsonPropertyName("meta")]
    public Metadata Metadata { get; set; }

    [JsonPropertyName("addresses")]
    public Address[] Addresses { get; set; }
}