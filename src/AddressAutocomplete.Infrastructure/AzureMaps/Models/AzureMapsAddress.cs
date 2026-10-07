using System.Text.Json.Serialization;

namespace AddressAutocomplete.Infrastructure.AzureMaps.Models;

public sealed class AzureMapsAddress
{
    [JsonPropertyName("addressLine")]
    public string? AddressLine { get; set; }

    [JsonPropertyName("formattedAddress")]
    public string? FormattedAddress { get; set; }

    [JsonPropertyName("streetName")]
    public string? StreetName { get; set; }

    [JsonPropertyName("streetNumber")]
    public string? StreetNumber { get; set; }

    [JsonPropertyName("neighborhood")]
    public string? Neighborhood { get; set; }

    [JsonPropertyName("locality")]
    public string? Locality { get; set; }

    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("adminDistricts")]
    public List<AzureMapsAdminDistrict> AdminDistricts { get; set; } = [];
}