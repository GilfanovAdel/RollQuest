using Application.DTO;

namespace Application.Services.JWTService;

public interface IJWTService
{
   AuthDTO GenerateTokens(GenerateTokensRequest request);
}