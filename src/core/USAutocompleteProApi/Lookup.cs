namespace SmartyStreets.USAutocompleteProApi
{
    using Refit;
    using System.Collections;
    using System.Runtime.Serialization;

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
        public string? Search { get; set; }

        [AliasAs("max_results")]
        public int? MaxResults { get; set; } = 10;

        public IEnumerable<string>? IncludeOnlyCities { get; set; }
        public IEnumerable<string>? IncludeOnlyStates { get; set; }
        public IEnumerable<string>? IncludeOnlyZipCodes { get; set; }
        public IEnumerable<string>? ExcludeStates { get; set; }
        public IEnumerable<string>? PreferCities { get; set; }
        public IEnumerable<string>? PreferStates { get; set; }
        public IEnumerable<string>? PreferZipCodes { get; set; }

        [AliasAs("prefer_ratio")]
        public int? PreferRatioFilter { get; set; }

        [AliasAs("prefer_geolocation")]
        public PreferGeolocation? PreferGeolocationFilter { get; set; } = PreferGeolocation.City;

        [AliasAs("selected")]
        public string? Selected { get; set; }

        [AliasAs("source")]
        public Source? SourceFilter { get; set; } = Source.Postal;

        [AliasAs("include_only_cities")]
        internal string? IncludeOnlyCitiesStr => BuildFilterString(IncludeOnlyCities);

        [AliasAs("include_only_states")]
        internal string? IncludeOnlyStatesStr => BuildFilterString(IncludeOnlyStates);

        [AliasAs("include_only_zip_codes")]
        internal string? IncludeOnlyZipCodesStr => BuildFilterString(IncludeOnlyZipCodes);

        [AliasAs("exclude_states")]
        internal string? ExcludeStatesStr => BuildFilterString(ExcludeStates);

        [AliasAs("prefer_cities")]
        internal string? PreferCitiesStr => BuildFilterString(PreferCities);

        [AliasAs("prefer_states")]
        internal string? PreferStatesStr => BuildFilterString(PreferStates);

        [AliasAs("prefer_zip_codes")]
        internal string? PreferZipCodesStr => BuildFilterString(PreferZipCodes);

        public enum PreferGeolocation
        {
            [EnumMember(Value = "none")]
            None = 1,

            [EnumMember(Value = "city")]
            City = 2
        }

        public enum Source
        {
            [EnumMember(Value = "all")]
            All = 1,

            [EnumMember(Value = "postal")]
            Postal = 2
        }

        private string? BuildFilterString(IEnumerable? collection, string separator = ";")
            => collection is null ? null : string.Join(separator, collection);
    }
}