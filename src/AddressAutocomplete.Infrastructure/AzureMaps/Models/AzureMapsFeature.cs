using System.Text.Json.Serialization;

namespace AddressAutocomplete.Infrastructure.AzureMaps.Models;

public sealed class AzureMapsFeature
{
    [JsonPropertyName("geometry")]
    public AzureMapsGeometry? Geometry { get; set; }

    [JsonPropertyName("properties")]
    public AzureMapsProperties? Properties { get; set; }
}