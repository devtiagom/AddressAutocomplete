using System.Text.Json.Serialization;

namespace AddressAutocomplete.Infrastructure.AzureMaps.Models;

public sealed class AzureMapsAutocompleteResponse
{
    [JsonPropertyName("features")]
    public List<AzureMapsFeature> Features { get; set; } = [];
}