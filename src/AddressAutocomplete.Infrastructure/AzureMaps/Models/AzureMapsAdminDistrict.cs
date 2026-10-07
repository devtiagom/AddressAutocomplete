using System.Text.Json.Serialization;

namespace AddressAutocomplete.Infrastructure.AzureMaps.Models;

public sealed class AzureMapsAdminDistrict
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("shortName")]
    public string? ShortName { get; set; }
}