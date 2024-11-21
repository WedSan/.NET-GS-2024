using WebApplication1.model;

namespace WebApplication1.DTO;

public record AddPanelSolarBudgetRequest(
    int addressId, 
    
    double investmentCost, 
    
    double systemSize,
     
    double amountModules, 
    
    double estimatedAnnualProduction 
    )
{
    
}