using System.Net.Http.Json;
using AddressAutocomplete.Application.DTOs;
using AddressAutocomplete.Application.Services;
using AddressAutocomplete.Infrastructure.AzureMaps.Models;
using Microsoft.Extensions.Options;

namespace AddressAutocomplete.Infrastructure.AzureMaps;

public sealed class AzureMapsAddressSearch : IAddressService
{
    private readonly HttpClient _httpClient;
    private readonly AzureMapsOptions _options;

    public AzureMapsAddressSearch(HttpClient httpClient, IOptions<AzureMapsOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<IReadOnlyList<AddressSuggestionDto>>
        GetSuggestionsAsync(
            string query,
            double? latitude,
            double? longitude,
            CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(query))
            return [];

        query = query.Trim();

        if (query.Length < 3)
            return [];

        var parameters = new List<string>
        {
            $"api-version={Uri.EscapeDataString(_options.ApiVersion)}",
            $"query={Uri.EscapeDataString(query)}",
            "countryRegion=BR",
            "resultTypeGroups=Address",
            "top=5"
        };

        if (latitude.HasValue && longitude.HasValue)
        {
            parameters.Add(
                $"coordinates={longitude.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)}," +
                $"{latitude.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
        }

        parameters.Add(
            $"subscription-key={Uri.EscapeDataString(_options.SubscriptionKey)}");

        var url =
            $"{_options.Endpoint}/geocode:autocomplete?" +
            string.Join("&", parameters);

        var response =
            await _httpClient.GetFromJsonAsync<AzureMapsAutocompleteResponse>(
                url,
                cancellationToken);

        if (response?.Features is null)
            return [];

        return response.Features
            .Select(MapSuggestion)
            .ToList();
    }

    public Task<long> CreateAsync(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private static AddressSuggestionDto MapSuggestion(AzureMapsFeature feature)
    {
        var address = feature.Properties?.Address;

        var state = address?
            .AdminDistricts
            .FirstOrDefault()?
            .ShortName;

        double? longitude = null;
        double? latitude = null;

        if (feature.Geometry?.Coordinates is { Length: >= 2 } coordinates)
        {
            longitude = coordinates[0];
            latitude = coordinates[1];
        }

        return new AddressSuggestionDto
        {
            AddressLine =
                address?.FormattedAddress
                ?? address?.AddressLine
                ?? string.Empty,

            Street = address?.StreetName,

            Number = address?.StreetNumber,

            Neighborhood = address?.Neighborhood,

            Municipality = address?.Locality,

            State = state,

            PostalCode = address?.PostalCode,

            Latitude = latitude,

            Longitude = longitude
        };
    }
}