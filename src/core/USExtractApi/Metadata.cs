using System.Text.Json.Serialization;

namespace Smarty.Net.Core.USExtractApi
{
    /// <summary>
    ///     See "https://smartystreets.com/docs/cloud/us-extract-api#http-response-status"
    /// </summary>
    public class Metadata
    {
        [JsonPropertyName("lines")]
        public int Lines { get; set; }

        [JsonPropertyName("unicode")]
        public bool Unicode { get; set; }

        [JsonPropertyName("address_count")]
        public int AddressCount { get; set; }

        [JsonPropertyName("verified_count")]
        public int VerifiedCount { get; set; }

        [JsonPropertyName("bytes")]
        public int Bytes { get; set; }

        [JsonPropertyName("character_count")]
        public int CharacterCount { get; set; }

    }
}