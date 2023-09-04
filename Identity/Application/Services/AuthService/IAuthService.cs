using Application.DTO;

namespace Application.Services.AuthService;

public interface IAuthService
{
    Task<AuthDTO> ConfirmCode(ConfirmCodeRequest request);

    Task<AuthDTO> ConfirmEmail( ConfirmEmailRequest request);

    Task Registration(RegistrationRequest request);
    
    Task Login(LoginRequest request);
    
    Task<AuthDTO> RefreshToken(string refreshToken);
}