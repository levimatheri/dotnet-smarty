namespace Smarty.Net.Core.USReverseGeoApi
{
	using System.Runtime.Serialization;
	using System.Text.Json.Serialization;

	/// <summary>
	///     See "https://smartystreets.com/docs/cloud/us-reverse-geo-api#coordinate"
	/// </summary>
	public class Coordinate
	{
		[JsonPropertyName("latitude")]
		public double Latitude { get; set; }

		[JsonPropertyName("longitude")]
		public double Longitude { get; set; }

		[JsonPropertyName("accuracy")]
		public AccuracyLevel Accuracy { get; set; }

		[JsonPropertyName("license")]
		public LicenseType License { get; set; }

		public enum AccuracyLevel
		{
			Unknown = 0,
			Zip5 = 1,
			Zip6 = 2,
			Zip7 = 3,
			Zip8 = 4,
			Zip9 = 5,
			Parcel = 6,
			Rooftop = 7
		}

		public enum LicenseType
		{
			SmartyStreets = 0,
			SmartyStreetsProprietary = 1
		}
	}
}