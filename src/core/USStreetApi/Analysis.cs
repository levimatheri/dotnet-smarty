using System.Text.Json.Serialization;

namespace Smarty.Net.Core.USStreetApi;

public class Analysis
{
    [JsonPropertyName("dpv_match_code")]
    public string? DpvMatchCode { get; set; }

    [JsonPropertyName("dpv_footnotes")]
    public string? DpvFootnotes { get; set; }

    [JsonPropertyName("dpv_cmra")]
    public string? Cmra { get; set; }

    [JsonPropertyName("dpv_vacant")]
    public string? Vacant { get; set; }

    [JsonPropertyName("dpv_no_stat")]
    public string? NoStat { get; set; }

    [JsonPropertyName("active")]
    public string? Active { get; set; }

    [Obsolete("Analysis.ews_match is deprecated, refer to Metadata.ews_match instead.")]
    [JsonPropertyName("ews_match")]
    public bool IsEwsMatch { get; set; }

    [JsonPropertyName("footnotes")]
    public string? Footnotes { get; set; }

    [JsonPropertyName("lacslink_code")]
    public string? LacsLinkCode { get; set; }

    [JsonPropertyName("lacslink_indicator")]
    public string? LacsLinkIndicator { get; set; }

    [JsonPropertyName("suitelink_match")]
    public bool IsSuiteLinkMatch { get; set; }

    [JsonPropertyName("enhanced_match")]
    public string? EnhancedMatch { get; set; }
}