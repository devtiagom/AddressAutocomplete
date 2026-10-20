using AddressAutocomplete.Application.DTOs;
using AddressAutocomplete.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddressAutocomplete.Api.Controllers;

[ApiController]
[Route("v1/api/addresses")]
public sealed class AddressController(IAddressSearchService searchService, IAddressPersistenceService persistenceService)
    : ControllerBase
{
    private readonly IAddressSearchService _addressSearchService = searchService;
    private readonly IAddressPersistenceService _addressPersistenceService = persistenceService;

    [HttpGet("suggestions")]
    public async Task<
            ActionResult<IReadOnlyList<AddressSuggestionResponseDto>>>
        GetSuggestions(
            [FromQuery] string query,
            [FromQuery] double? latitude,
            [FromQuery] double? longitude,
            CancellationToken cancellationToken)
    {
        var suggestions = await _addressSearchService.GetSuggestionsAsync(
                query,
                latitude,
                longitude,
                cancellationToken);

        return Ok(suggestions);
    }

    [HttpPost]
    public async Task<ActionResult<long>> Create(
        [FromBody] CreateAddressRequest request,
        CancellationToken cancellationToken)
    {
        var id = await _addressPersistenceService.CreateAsync(request, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult> GetById(long id)
    {
        return Ok();
    }
}