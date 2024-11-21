namespace WebApplication1.model;

public class Address
{
    public int id { get; set; }

    public virtual User user { get; set; }

    public string street { get; set; }
    
    public string neighborhood { get; set; }

    public string postalCode { get; set; }
    
    public string houseNumber { get; set; }
    
    public string city { get; set; }
    
    public string localType { get; set; }

    public Address()
    {
    }

    public Address(User user, string street, string neighborhood, string postalCode, string houseNumber, string city, string localType)
    {
        this.user = user;
        this.street = street;
        this.neighborhood = neighborhood;
        this.postalCode = postalCode;
        this.houseNumber = houseNumber;
        this.city = city;
        this.localType = localType;
    }

    public Address(int id, User user, string street, string neighborhood, string postalCode, string houseNumber, string city, string localType)
    {
        this.id = id;
        this.user = user;
        this.street = street;
        this.neighborhood = neighborhood;
        this.postalCode = postalCode;
        this.houseNumber = houseNumber;
        this.city = city;
        this.localType = localType;
    }
}