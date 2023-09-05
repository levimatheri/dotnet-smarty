namespace Smarty.Net.Core.Apis.USReverseGeoApi
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