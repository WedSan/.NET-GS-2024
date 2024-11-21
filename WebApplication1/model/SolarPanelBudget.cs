namespace WebApplication1.model;

public class SolarPanelBudget
{
    public int Id { get; set; }
    
    public virtual Address address { get; set; }
    
    public double investmentCost { get; set; }
    
    public double systemSize { get; set; }
    
    public double amountModules { get; set; }
    
    public double estimatedAnnualProduction { get; set; }

    public SolarPanelBudget()
    {
    }

    public SolarPanelBudget(int id, Address address, double investmentCost, double systemSize, double amountModules, double estimatedAnnualProduction)
    {
        Id = id;
        this.address = address;
        this.investmentCost = investmentCost;
        this.systemSize = systemSize;
        this.amountModules = amountModules;
        this.estimatedAnnualProduction = estimatedAnnualProduction;
    }

    public SolarPanelBudget(Address address, double investmentCost, double systemSize, double amountModules, double estimatedAnnualProduction)
    {
        this.address = address;
        this.investmentCost = investmentCost;
        this.systemSize = systemSize;
        this.amountModules = amountModules;
        this.estimatedAnnualProduction = estimatedAnnualProduction;
    }
}