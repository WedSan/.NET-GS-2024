namespace WebApplication1.DTO;

public record AddressResponse(
    int id,
    
    int userID,

    string street,
        
    string neighborhood,

    string postalCode,
        
    string houseNumber,
        
    string city,
        
    string localType
    );