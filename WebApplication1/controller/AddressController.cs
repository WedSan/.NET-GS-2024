using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;


namespace WebApplication1.controller;


[ApiController]
[Route("api/v1/address")]
public class AddressController : Controller
{
    private AddressService _addressService;

    public AddressController(AddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAddress([FromBody] AddAddressRequest address)
    {
        AddressResponse reponse = await _addressService.CreateAddressAsync(
            address.userId,

            address.street,

            address.neighborhood,

            address.postalCode,

            address.houseNumber,

            address.city,

            address.localType);
        
        return CreatedAtAction(nameof(CreateAddress), reponse);
    }

    [HttpGet]
    public async Task<ActionResult> GetAddress(int pageNumber = 1, int pageSize = 10)
    {
        IEnumerable<AddressResponse> responseList = await _addressService.GetAddressesAsync(
            pageNumber, pageSize);
        return Ok(responseList);
    }
    
    [HttpGet("/{addressId}")]
    public async Task<ActionResult> GetAddress(int addressId)
    {
        AddressResponse responseList = await _addressService.GetAddressByIdAsync(addressId);
        return Ok(responseList);
    }
    
    [HttpDelete("{addressId}")]
    public async Task<ActionResult> DeleteAddress(int addressId)
    {
        await _addressService.DeleteAddressAsync(addressId);
        return NoContent();
    }
}