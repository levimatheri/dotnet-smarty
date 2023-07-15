namespace Smarty.Net.Core.USReverseGeoApi
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    /// <summary>
    ///     See "https://smartystreets.com/docs/cloud/us-reverse-geo-api#address"
    /// </summary>
    public class Address
	{
		[JsonPropertyName("street")]
		public string? Street { get; set; }

		[JsonPropertyName("city")]
		public string? City { get; set; }

		[JsonPropertyName("state_abbreviation")]
		public string? StateAbbreviation { get; set; }

		[JsonPropertyName("zipcode")]
		public string? ZipCode { get; set; }
		
		[JsonPropertyName("source")]
		public DataSource? Source { get; set; }

		public enum DataSource
		{
			[EnumMember(Value = "postal")]
			Postal = 1,
			
			[EnumMember(Value = "other")]
			Other = 2
		}
	}
}