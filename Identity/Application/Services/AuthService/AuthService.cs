using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using Application.Commands.CreateUser;
using Application.Commands.UpdateUser;
using Application.DTO;
using Application.Exceptions;
using Application.Queries.GetByRefreshToken;
using Application.Queries.GetUserByEmail;
using Application.Services.CodeService;
using Application.Services.EmailService;
using Application.Services.JWTService;
using FluentValidation;
using MediatR;
using OtpNet;

namespace Application.Services.AuthService;

public class AuthService : IAuthService
{
    private IMediator _mediator;
    private IJWTService _jwtService;
    private IEmailService _emailService;
    private ICodeService _codeService;


    public AuthService(IMediator mediator, IJWTService jwtService, IEmailService emailService, ICodeService codeService)
    {
        _mediator = mediator;
        _jwtService = jwtService;
        _emailService = emailService;
        _codeService = codeService;
    }

    public async Task<AuthDTO> ConfirmCode(ConfirmCodeRequest request)
    {
        var user = await _mediator.Send(new GetUserByEmailQuery() { Email = request.Email });
        if (user is not null)
        {
            var success = _codeService.Verification(new VerificationRequest()
                { Code = request.Code, SecretKey = user.SecretKey });
            if (success)
            {
                var tokens = _jwtService.GenerateTokens(new GenerateTokensRequest()
                    { Id = user.Id.ToString(), Role = user.Role });
                user.RefreshToken = tokens.RefreshToken;
                await _mediator.Send(new UpdateUserCommand() { User = user });
                return tokens;
            }

            throw new ConflictException("неверный код");
        }

        throw new ConflictException("пользователя с такой почтой не существует");
    }

    public async Task<AuthDTO> ConfirmEmail(ConfirmEmailRequest request)
    {
        var user = await _mediator.Send(new GetUserByEmailQuery() { Email = request.Email });
        var success = _codeService.Verification(new VerificationRequest()
            { Code = request.Code, SecretKey = user.SecretKey });
        if (success)
        {
            var tokens = _jwtService.GenerateTokens(new GenerateTokensRequest()
                { Id = user.Id.ToString(), Role = user.Role });
            user.Role = "Confirmed";
            user.RefreshToken = tokens.RefreshToken;
            await _mediator.Send(new UpdateUserCommand() { User = user });
            return tokens;
        }

        throw new ConflictException("ссылка не действительна");
    }

    public async Task Registration(RegistrationRequest request)
    {
        
     
        var user = await _mediator.Send(new GetUserByEmailQuery() { Email = request.Email });

        if (user is not null)
        {
            throw new ConflictException("пользователь с такой почтой существует");
        }

        var secretKey = GenerateSecretKey();
        await _mediator.Send(new CreateUserCommand()
            { Email = request.Email, Name = request.Name, SecretKey = secretKey });
        var code = _codeService.Generate(new GenerateRequest() { SecretKey = secretKey });
        await _emailService.SendConfirmLink(new SendLinkRequest() { Email = request.Email, Code = code });
    }

    public async Task Login(LoginRequest request)
    {
        var user = await _mediator.Send(new GetUserByEmailQuery() { Email = request.Email });

        if (user is null)
        {
            throw new ConflictException("пользователя с такой почтой не существует");
        }

        var code = _codeService.Generate(new GenerateRequest() { SecretKey = user.SecretKey });
        await _emailService.SendCode(new SendCodeRequest() { Code = code });
    }

    public async Task<AuthDTO> RefreshToken(string refreshToken)
    {
        if (refreshToken is null)
        {
            throw new ConflictException("недействительный рефреш токен");
        }

        var user = await _mediator.Send(new GetByRefreshTokenQuery() { RefreshToken = refreshToken });
        if (user is null)
        {
            throw new ConflictException("недействительный рефреш токен");
        }

        var authDto = _jwtService.GenerateTokens(new GenerateTokensRequest()
            { Id = user.Id.ToString(), Role = user.Role });
        user.RefreshToken = authDto.RefreshToken;
        await _mediator.Send(new UpdateUserCommand() { User = user });
        return  authDto ;
    }

    private string GenerateSecretKey(int byteLength = 20)
    {
        var rng = new RNGCryptoServiceProvider();
        var bytes = new byte[byteLength];
        rng.GetBytes(bytes);
        var base32 = Base32Encoding.ToString(bytes);
        return base32;
    }
}