namespace Smarty.Net.Core.Apis.InternationalStreetApi
{
    using System.Runtime.Serialization;

    /// <summary>
    ///     See "https://smartystreets.com/docs/cloud/international-street-api#metadata"
    /// </summary>
    [DataContract]
    public class Metadata
    {
        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }

        [DataMember(Name = "geocode_precision")]
        public GeocodePrecisionType GeocodePrecision { get; set; }

        [DataMember(Name = "max_geocode_precision")]
        public GeocodePrecisionType MaxGeocodePrecision { get; set; }

        [DataMember(Name = "address_format")]
        public string? AddressFormat { get; set; }

        public enum GeocodePrecisionType
        {
            None = 0,
            AdministrativeArea = 1,
            Locality = 2,
            Thoroughfare = 3,
            Premise = 4,
            DeliveryPoint = 5
        }
    }
}