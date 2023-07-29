namespace Smarty.Net.Core.USReverseGeoApi
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [DataContract]
    public class SmartyResponse
    {
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
    }
}