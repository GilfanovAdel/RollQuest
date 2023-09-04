using Microsoft.Extensions.Configuration;

namespace Application.Services.EmailService;

public class EmailService : IEmailService
{
    private IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendCode(SendCodeRequest request)
    {
    
        Console.WriteLine(request.Code);
        
        /*var message = new MimeMessage();
       message.From.Add(new MailboxAddress(_configuration["Publisher"], _configuration["Email"]));
       message.To.Add(new MailboxAddress("Client", request.Email));
       message.Subject = "Code";
       
       message.Body = new TextPart("plain")
       {
           Text = $"Code {code.Value}"
       };

       using (var client = new SmtpClient())
       {
           var port = Convert.ToInt32(_configuration["SmtpPort"]);
           var domain = _configuration["SmtpDomain"];
           var authPassword = _configuration["SmtpAuthPassword"];
           var authName = _configuration["SmtpAuthName"];
           await client.ConnectAsync(domain, port, true);
           await client.AuthenticateAsync(authName, authPassword);
           await client.SendAsync(message);
           await client.DisconnectAsync(true);
       }*/
    }

    public async Task SendConfirmLink(SendLinkRequest request)
    {
      
        Console.WriteLine($"{_configuration["FrontDomain"]}/confirmemail?code={request.Code}&email={request.Email}");

        /*var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_configuration["Publisher"], _configuration["Email"]));
        message.To.Add(new MailboxAddress("Client", request.Email));
        message.Subject = "Code";

        message.Body = new TextPart("plain")
        {
            Text =
                $"Пожалуйста, нажмите на ссылку для подтверждения электронной почты http://localhost:5244/confirmemail?code={code.Value}&email={request.Email}"
        };

        using (var client = new SmtpClient())
        {
            var port = Convert.ToInt32(_configuration["SmtpPort"]);
            var domain = _configuration["SmtpDomain"];
            var authPassword = _configuration["SmtpAuthPassword"];
            var authName = _configuration["SmtpAuthName"];
            await client.ConnectAsync(domain, port, true);
            await client.AuthenticateAsync(authName, authPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }*/
    }
}