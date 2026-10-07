using System.Text.Json.Serialization;

namespace AddressAutocomplete.Infrastructure.AzureMaps.Models;

public sealed class AzureMapsProperties
{
    [JsonPropertyName("typeGroup")]
    public string? TypeGroup { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("address")]
    public AzureMapsAddress? Address { get; set; }
}