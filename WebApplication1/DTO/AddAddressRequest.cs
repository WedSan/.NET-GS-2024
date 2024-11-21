namespace WebApplication1.DTO;

public record AddAddressRequest(
    int userId,

    string street,
        
    string neighborhood,

    string postalCode,
        
    string houseNumber,
        
    string city,
        
    string localType
    )
{
    
}