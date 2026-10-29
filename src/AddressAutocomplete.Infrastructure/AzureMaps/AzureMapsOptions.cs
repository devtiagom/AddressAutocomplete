namespace AddressAutocomplete.Infrastructure.AzureMaps;

public sealed class AzureMapsOptions
{
    public const string SectionName = "AzureMaps";

    public string Endpoint { get; set; } = "https://atlas.microsoft.com";

    public string SubscriptionKey { get; set; } = string.Empty;

    public string ApiVersion { get; set; } = "2026-01-01";

    public string DefaultBoundingBox { get; set; } = "-74,-34,-34,6";
}