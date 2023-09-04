namespace Application.Services.AuthService;

public class ConfirmEmailRequest
{
    public  string Code { get; set; }
    
    public  string Email { get; set; }
}