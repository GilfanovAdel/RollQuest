namespace Application.Services.JWTService;

public class GenerateTokensRequest
{
    public  string Id { get; set; }
    
    public  string Role { get; set; }
}