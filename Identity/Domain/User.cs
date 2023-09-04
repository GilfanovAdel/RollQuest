using Microsoft.AspNet.Identity;

namespace Domain;

public class User 
{
    public User( string userName, string email)
    {
        Id = Guid.NewGuid();
        Name = userName;
        Email = email;
    }

    public User()
    {
    }

    public Guid Id { get; }

    public string Name { get; set; }

    public string Email { get; set; }
    
    public  string SecretKey { get; set; }

    public string  RefreshToken { get; set; }

    public string Role { get; set; }
}