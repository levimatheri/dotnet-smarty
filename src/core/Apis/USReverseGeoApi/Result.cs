namespace Smarty.Net.Core.Apis.USReverseGeoApi
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    /// <summary>
    ///     A result is a possible match for an lat/lon that was submitted.
    ///     A lookup can have multiple results if the address was ambiguous.
    /// </summary>
    /// <remarks>See "https://smartystreets.com/docs/cloud/us-reverse-geo-api#result"</remarks>
    [DataContract]
    public class Result
    {
        [JsonPropertyName("coordinate")]
        public Coordinate Coordinate { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }
}