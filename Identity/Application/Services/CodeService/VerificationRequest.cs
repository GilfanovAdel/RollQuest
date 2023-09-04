namespace Application.Services.CodeService;

public class VerificationRequest
{
    public  string Code { get; set; }
    public  string  SecretKey { get; set; }
}