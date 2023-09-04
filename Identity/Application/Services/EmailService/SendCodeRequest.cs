namespace Application.Services.EmailService;

public class SendCodeRequest
{
    public  string Email { get; set; }
    
    public  string Code { get; set; }
}