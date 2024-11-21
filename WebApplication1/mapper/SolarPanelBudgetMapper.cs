using WebApplication1.DTO;
using WebApplication1.model;

namespace WebApplication1.mapper;

public class SolarPanelBudgetMapper
{
    public static SolarPanelBudgetResponse toDTO(SolarPanelBudget solarPanelBudget)
    {
        return new SolarPanelBudgetResponse(
            solarPanelBudget.Id,
            solarPanelBudget.address.id,
            solarPanelBudget.investmentCost,
            solarPanelBudget.systemSize,
            solarPanelBudget.amountModules,
            solarPanelBudget.estimatedAnnualProduction
        );
    }
    
    public static IEnumerable<SolarPanelBudgetResponse> toDTO(IEnumerable<SolarPanelBudget> solarPanelBudgetList)
    {
        List<SolarPanelBudgetResponse> solarPanelBudgetResponses = new List<SolarPanelBudgetResponse>();
        foreach (var solarPanelBudget in solarPanelBudgetList)
        {
            solarPanelBudgetResponses.Add(toDTO(solarPanelBudget));
        }
        
        return solarPanelBudgetResponses;
    }
}