namespace Application.Services.EmailService;

public interface IEmailService
{
    Task SendCode( SendCodeRequest request);

    Task SendConfirmLink( SendLinkRequest request);
}