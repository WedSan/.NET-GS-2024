namespace WebApplication1.model;

public class User
{
    public int Id { get; set; }

    public string Name { get; init; }

    public string Email { get; set; }

    public string Password { get; set; }    
    
    public string Telephone { get; set; }

    public User(int id, string name, string email, string password, string telephone)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Telephone = telephone;
    }
    
    public User(string name, string email, string password, string telephone)
    {
        Name = name;
        Email = email;
        Password = password;
        Telephone = telephone;
    }
}