using AddressAutocomplete.Application.DTOs;

namespace AddressAutocomplete.Application.Services;

public interface IAddressService
{
    Task<IReadOnlyList<AddressSuggestionDto>>
        GetSuggestionsAsync(
            string query,
            double? latitude,
            double? longitude,
            CancellationToken cancellationToken);

    Task<long> CreateAsync(
        CreateAddressRequest request,
        CancellationToken cancellationToken);
}