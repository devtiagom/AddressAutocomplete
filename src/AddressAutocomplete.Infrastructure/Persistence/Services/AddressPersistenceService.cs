using AddressAutocomplete.Application.DTOs;
using AddressAutocomplete.Application.Services;
using AddressAutocomplete.Infrastructure.Persistence.Entities;

namespace AddressAutocomplete.Infrastructure.Persistence.Services;

public sealed class AddressPersistenceService(AppDbContext dbContext) : IAddressPersistenceService
{
    public async Task<long> CreateAsync(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        var address = new Address
        {
            Street = request.Street,
            Number = request.Number,
            Neighborhood = request.Neighborhood,
            Complement = request.Complement,
            Municipality = request.Municipality,
            State = request.State,
            PostalCode = request.PostalCode,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            FormattedAddress = request.FormattedAddress,
            CreatedAt = DateTime.UtcNow
        };

        dbContext.Addresses.Add(address);
        await dbContext.SaveChangesAsync(cancellationToken);
        return address.Id;
    }
}