namespace AddressAutocomplete.Application.DTOs;

public sealed class AddressSuggestionDto
{
    public string AddressLine { get; init; } = string.Empty;

    public string? Street { get; init; }

    public string? Number { get; init; }

    public string? Neighborhood { get; init; }

    public string? Municipality { get; init; }

    public string? State { get; init; }

    public string? PostalCode { get; init; }

    public double? Latitude { get; init; }

    public double? Longitude { get; init; }
}