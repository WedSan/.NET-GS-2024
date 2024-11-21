using WebApplication1.DTO;
using WebApplication1.model;

namespace WebApplication1.mapper;

public class AddressMapper
{
    
    public static AddressResponse toDTO(Address address)
    {
        return new AddressResponse(
            address.id,
            address.user.Id,
            address.street,
            address.neighborhood,
            address.postalCode,
            address.houseNumber,
            address.city,
            address.localType
        );
    }

    public static IEnumerable<AddressResponse> toDTO(IEnumerable<Address> addresses)
    {
        List<AddressResponse> addressResponseList = new List<AddressResponse>();
        foreach (var address in addresses)
        {
            addressResponseList.Add(toDTO(address));
        }
        return addressResponseList;
    }
}