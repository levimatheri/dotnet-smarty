namespace Smarty.Net.Core.Apis.InternationalStreetApi
{
    using Refit;
    using Smarty.Net.Core.Apis.Shared;
    using System.Runtime.Serialization;

    public class Lookup : ILookup
    {
        [AliasAs("input_id")]
        public string? InputId { get; set; }

        [AliasAs("country")]
        public required string Country { get; set; }

        [AliasAs("geocode")]
        public bool? Geocode { get; set; } = false;

        [AliasAs("language")]
        public LanguageType? Language { get; set; }

        [AliasAs("freeform")]
        public string? Freeform { get; set; }

        [AliasAs("address1")]
        public string? Address1 { get; set; }

        [AliasAs("address2")]
        public string? Address2 { get; set; }

        [AliasAs("address3")]
        public string? Address3 { get; set; }

        [AliasAs("address4")]
        public string? Address4 { get; set; }

        [AliasAs("organization")]
        public string? Organization { get; set; }

        [AliasAs("locality")]
        public string? Locality { get; set; }

        [AliasAs("administrative_area")]
        public string? AdministrativeArea { get; set; }

        [AliasAs("postal_code")]
        public string? PostalCode { get; set; }

        [AliasAs("license")]
        public string? License { get; set; }

        public enum LanguageType
        {
            [EnumMember(Value = "native")]
            Native = 1,

            [EnumMember(Value = "latin")]
            Latin = 2
        }

    }
}