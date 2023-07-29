﻿namespace Smarty.Net.Core.InternationalAutocompleteApi
{
    using System.Runtime.Serialization;

    /// <remarks>
    ///     See "https://smartystreets.com/docs/cloud/us-autocomplete-api#http-response"
    /// </remarks>
    /// >
    [DataContract]
    public class Candidate
    {
        [DataMember(Name = "street")]
        public string? Street { get; set; }

        [DataMember(Name = "locality")]
        public string? Locality { get; set; }

        [DataMember(Name = "administrative_area")]
        public string? AdministrativeArea { get; set; }

        [DataMember(Name = "super_administrative_area")]
        public string? SuperAdministrativeArea { get; set; }

        [DataMember(Name = "sub_administrative_area")]
        public string? SubAdministrativeArea { get; set; }

        [DataMember(Name = "postal_code")]
        public string? PostalCode { get; set; }

        [DataMember(Name = "country_iso3")]
        public string? CountryISO3 { get; set; }
    }
}