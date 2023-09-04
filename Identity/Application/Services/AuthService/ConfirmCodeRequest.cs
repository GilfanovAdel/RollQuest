namespace Application.Services.AuthService;

public class ConfirmCodeRequest
{
    public  string Code { get; set; }
    
    public  string Email { get; set; }
}