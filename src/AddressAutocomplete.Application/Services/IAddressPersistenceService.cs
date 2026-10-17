using AddressAutocomplete.Application.DTOs;

namespace AddressAutocomplete.Application.Services;

public interface IAddressPersistenceService
{
    Task<long> CreateAsync(
        CreateAddressRequest request,
        CancellationToken cancellationToken);
}