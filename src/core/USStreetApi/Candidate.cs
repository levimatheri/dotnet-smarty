using System.Text.Json.Serialization;

namespace Smarty.Net.Core.USStreetApi;

public class Candidate
{
    [JsonPropertyName("input_id")]
    public string? InputId { get; set; }

    [JsonPropertyName("input_index")]
    public int InputIndex { get; set; }

    [JsonPropertyName("candidate_index")]
    public int CandidateIndex { get; set; }

    [JsonPropertyName("addressee")]
    public string? Addressee { get; set; }

    [JsonPropertyName("delivery_line_1")]
    public string? DeliveryLine1 { get; set; }

    [JsonPropertyName("delivery_line_2")]
    public string? DeliveryLine2 { get; set; }

    [JsonPropertyName("last_line")]
    public string? LastLine { get; set; }

    [JsonPropertyName("delivery_point_barcode")]
    public string? DeliveryPointBarcode { get; set; }

    [JsonPropertyName("smarty_key")]
    public string? SmartyKey { get; set; }

    [JsonPropertyName("components")]
    public Components? Components { get; set; }

    [JsonPropertyName("metadata")]
    public Metadata? Metadata { get; set; }

    [JsonPropertyName("analysis")]
    public Analysis? Analysis { get; set; }
}