namespace AddressAutocomplete.Infrastructure.Persistence.Entities;

public class Address
{
    public long Id { get; set; }

    public string? Street { get; set; }

    public string? Number { get; set; }

    public string? Neighborhood { get; set; }

    public string? Complement { get; set; }

    public string? Municipality { get; set; }

    public string? State { get; set; }

    public string? PostalCode { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public string FormattedAddress { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}