using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;

namespace WebApplication1.controller;

[ApiController]
[Route("api/v1/solar-panel-budget")]
public class SolarPanelBudgetController : Controller
{
    private SolarPanelBudgetService _solarPanelBudgetService;

    public SolarPanelBudgetController(SolarPanelBudgetService solarPanelBudgetService)
    {
        _solarPanelBudgetService = solarPanelBudgetService;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateSolarPanelBudget([FromBody] AddPanelSolarBudgetRequest req)
    {
        SolarPanelBudgetResponse response = await _solarPanelBudgetService.CreateSolarPanelBudgetResponse(req.addressId,

            req.investmentCost,

            req.systemSize,

            req.amountModules,

            req.estimatedAnnualProduction);
        
        return CreatedAtAction(nameof(CreateSolarPanelBudget), response);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllSolarPanelBudget(int pageNumber = 1, int pageSize = 10)
    {
        IEnumerable<SolarPanelBudgetResponse> responseList = await _solarPanelBudgetService.GetSolarPanelBudgets(pageNumber, pageSize);
        return Ok(responseList);
    }
    
    [HttpGet("{solarPanelBudgetId}")]
    public async Task<ActionResult> GetSolarPanelBudgetById(int solarPanelBudgetId)
    {
        SolarPanelBudgetResponse response = await _solarPanelBudgetService.GetSolarPanelBudgets(solarPanelBudgetId);
        
        return Ok(response);
    }

    [HttpDelete("{solarPanelBudgetId}")]
    public async Task<ActionResult> DeleteSolarPanelBudget(int solarPanelBudgetId)
    {
        await _solarPanelBudgetService.DeleteSolarPanelBudget(solarPanelBudgetId);
        return NoContent();
    }
        
}