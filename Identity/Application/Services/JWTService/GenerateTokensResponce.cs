namespace Application.Services.JWTService;

public class GenerateTokensResponce
{
    public string AccessToken { get; set; }
    
    public string RefreshToken { get; set; }
}