using System.Text.Json.Serialization;

namespace Smarty.Net.Core.USStreetApi;

public class Components
{

    [JsonPropertyName("urbanization")]
    public string? Urbanization { get; set; }

    [JsonPropertyName("primary_number")]
    public string? PrimaryNumber { get; set; }

    [JsonPropertyName("street_name")]
    public string? StreetName { get; set; }

    [JsonPropertyName("street_predirection")]
    public string? StreetPredirection { get; set; }

    [JsonPropertyName("street_postdirection")]
    public string? StreetPostdirection { get; set; }

    [JsonPropertyName("street_suffix")]
    public string? StreetSuffix { get; set; }

    [JsonPropertyName("secondary_number")]
    public string? SecondaryNumber { get; set; }

    [JsonPropertyName("secondary_designator")]
    public string? SecondaryDesignator { get; set; }

    [JsonPropertyName("extra_secondary_number")]
    public string? ExtraSecondaryNumber { get; set; }

    [JsonPropertyName("extra_secondary_designator")]
    public string? ExtraSecondaryDesignator { get; set; }

    [JsonPropertyName("pmb_designator")]
    public string? PmbDesignator { get; set; }

    [JsonPropertyName("pmb_number")]
    public string? PmbNumber { get; set; }

    [JsonPropertyName("city_name")]
    public string? CityName { get; set; }

    [JsonPropertyName("default_city_name")]
    public string? DefaultCityName { get; set; }

    [JsonPropertyName("state_abbreviation")]
    public string? State { get; set; }

    [JsonPropertyName("zipcode")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("plus4_code")]
    public string? Plus4Code { get; set; }

    [JsonPropertyName("delivery_point")]
    public string? DeliveryPoint { get; set; }

    [JsonPropertyName("delivery_point_check_digit")]
    public string? DeliveryPointCheckDigit { get; set; }
}