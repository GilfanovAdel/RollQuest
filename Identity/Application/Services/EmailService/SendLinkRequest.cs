namespace Application.Services.EmailService;

public class SendLinkRequest
{
    public  string Email { get; set; }
    
    public  string Code { get; set; }
}