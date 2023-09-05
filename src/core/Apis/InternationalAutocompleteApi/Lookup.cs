namespace Smarty.Net.Core.Apis.InternationalAutocompleteApi
{
    using Refit;

    /// <summary>
    ///     In addition to holding all of the input data for this lookup, this class also
    ///     will contain the result of the lookup after it comes back from the API.
    /// </summary>
    /// <remarks>
    ///     See "https://smartystreets.com/docs/cloud/us-autocomplete-api#http-request-input-fields"
    /// </remarks>
    public class Lookup
    {
        [AliasAs("search")]
        public required string Search { get; set; }

        [AliasAs("country")]
        public required string Country { get; set; }

        [AliasAs("max_results")]
        public int? MaxResults { get; set; } = 5;

        [AliasAs("include_only_administrative_area")]
        public string? AdministrativeArea { get; set; }

        [AliasAs("include_only_locality")]
        public string? Locality { get; set; }

        [AliasAs("include_only_postal_code")]
        public string? PostalCode { get; set; }

        [AliasAs("distance")]
        public int? Distance { get; set; } = 5;

        [AliasAs("geolocation")]
        public string? Geolocation { get; set; }

        [AliasAs("latitude")]
        public string? Latitude { get; set; }

        [AliasAs("longitude")]
        public string? Longitude { get; set; }
    }
}