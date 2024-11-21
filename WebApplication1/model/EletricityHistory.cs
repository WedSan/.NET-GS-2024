namespace WebApplication1.model;

public class EletricityHistory
{
    public int id { get; set; }
    
    public virtual Address address { get; set; }
    
    public double eletricityConsumption { get; set; }

    public string unitMeasurement {get; set;}
    
    public DateTime registrationDate { get; set; }
    
    public double cost { get; set;}

    public EletricityHistory()
    {
    }

    public EletricityHistory(int id, Address address, double eletricityConsumption, string unitMeasurement, DateTime registrationDate, double cost)
    {
        this.id = id;
        this.address = address;
        this.eletricityConsumption = eletricityConsumption;
        this.unitMeasurement = unitMeasurement;
        this.registrationDate = registrationDate;
        this.cost = cost;
    }

    public EletricityHistory(Address address, double eletricityConsumption, string unitMeasurement, DateTime registrationDate, double cost)
    {
        this.address = address;
        this.eletricityConsumption = eletricityConsumption;
        this.unitMeasurement = unitMeasurement;
        this.registrationDate = registrationDate;
        this.cost = cost;
    }
}