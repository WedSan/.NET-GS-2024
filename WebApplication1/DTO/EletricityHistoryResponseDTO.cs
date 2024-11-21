namespace WebApplication1.DTO;

public record EletricityHistoryResponseDTO(
    int id,
    
    int addressId ,
        
    double eletricityConsumption ,

    string unitMeasurement ,
        
    DateTime registrationDate ,
    double cost 
    )
{
    
}