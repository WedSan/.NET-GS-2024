namespace WebApplication1.DTO;

public record SolarPanelBudgetResponse(
    int id,
    
    int addressId, 
    
    double investmentCost, 
    
    double systemSize,
     
    double amountModules, 
    
    double estimatedAnnualProduction 
    )
{
    
}