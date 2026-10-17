using AddressAutocomplete.Application.DTOs;

namespace AddressAutocomplete.Application.Services;

public interface IAddressSearchService
{
    Task<IReadOnlyList<AddressSuggestionResponseDto>>
        GetSuggestionsAsync(
            string query,
            double? latitude,
            double? longitude,
            CancellationToken cancellationToken);
}