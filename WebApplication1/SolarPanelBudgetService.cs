
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.exception;
using WebApplication1.mapper;
using WebApplication1.model;

namespace WebApplication1;

public class SolarPanelBudgetService
{
    private AppDbContext _repository;
    
    private AddressService _addressService;

    public SolarPanelBudgetService(AppDbContext repository, AddressService addressService)
    {
        _repository = repository;
        _addressService = addressService;
    }

    public async Task<SolarPanelBudgetResponse> CreateSolarPanelBudgetResponse(
        int addressId, 
    
        double investmentCost, 
    
        double systemSize,
     
        double amountModules, 
    
        double estimatedAnnualProduction )
    {

        Address addressFounded = await _addressService.FindAddressByIdAsync(addressId);
        
        SolarPanelBudget solarPanelBudget = new SolarPanelBudget(
            addressFounded,
            investmentCost,
            systemSize,
            amountModules,
            estimatedAnnualProduction);

        await _repository.SolarPanelBudgets.AddAsync(solarPanelBudget);
        await _repository.SaveChangesAsync();
        return SolarPanelBudgetMapper.toDTO(solarPanelBudget);
    }
    
    public async Task<IEnumerable<SolarPanelBudgetResponse>> GetSolarPanelBudgets(int pageNumber, int pageSize)
    {
        IEnumerable<SolarPanelBudget> solarPanelBudgetsList = await _repository.SolarPanelBudgets
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return SolarPanelBudgetMapper.toDTO(solarPanelBudgetsList);
    }
    
    public async Task<SolarPanelBudgetResponse> GetSolarPanelBudgets(int solarPanelBudgetId)
    {
        SolarPanelBudget solarPanelBudget = await FindSolarPanelBudget(solarPanelBudgetId);
        return SolarPanelBudgetMapper.toDTO(solarPanelBudget);
    }

    public async Task DeleteSolarPanelBudget(int solarPanelBudgetId)
    {
        SolarPanelBudget solarPanelBudget = await FindSolarPanelBudget(solarPanelBudgetId);
        _repository.SolarPanelBudgets.Remove(solarPanelBudget);
        await _repository.SaveChangesAsync();
    }

    public async Task<SolarPanelBudget> FindSolarPanelBudget(int id)
    {
        SolarPanelBudget? solarPanelBudgetFounded = 
            await _repository.SolarPanelBudgets.FindAsync(id);
         
        if (solarPanelBudgetFounded == null)
        {
            throw new EntityNotFoundException("Solar panel budget not found");
        }
        
        return solarPanelBudgetFounded;
    }
}