using WebApplication1.model;

namespace WebApplication1.DTO;

public record AddEletricityHistoryDTO(
        
    int addressId ,
        
    double eletricityConsumption ,

    string unitMeasurement ,
        
    DateTime registrationDate ,
    double cost 
    )
{
    
}