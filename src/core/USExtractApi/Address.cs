using Smarty.Net.Core.USStreetApi;
using System.Text.Json.Serialization;

namespace Smarty.Net.Core.USExtractApi
{

    /// <summary>
    ///     See "https://smartystreets.com/docs/cloud/us-extract-api#http-response-status"
    /// </summary>
    public class Address
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("verified")]
        public bool Verified { get; set; }

        [JsonPropertyName("line")]
        public int Line { get; set; }

        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }

        [JsonPropertyName("api_output")]
        public Candidate[] Candidates { get; set; }
    }
}