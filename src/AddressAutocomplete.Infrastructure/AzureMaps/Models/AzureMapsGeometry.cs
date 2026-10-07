using System.Text.Json.Serialization;

namespace AddressAutocomplete.Infrastructure.AzureMaps.Models;

public sealed class AzureMapsGeometry
{
    [JsonPropertyName("coordinates")]
    public double[] Coordinates { get; set; } = [];
}