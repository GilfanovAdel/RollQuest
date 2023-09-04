using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.JWTService;

public class JWTService : IJWTService
{
    private IConfiguration _configuration;

    public JWTService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AuthDTO GenerateTokens(GenerateTokensRequest request)
    {
        return new AuthDTO()
            { AccessToken = GenerateAccessToken( request), RefreshToken = GenerateRefreshToken() };
    }

    private string GenerateAccessToken(GenerateTokensRequest request)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSecretKey"]));

        var claims = new List<Claim>
        {
            new Claim("Id", request.Id),
            new Claim(ClaimTypes.Role, request.Role)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JWTAccessTokenExpirationMinutes"])),
            SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = tokenHandler.WriteToken(jwtToken);

        return accessToken;
    }

    private string GenerateRefreshToken()
    {
        var refreshToken = Guid.NewGuid().ToString();
        return refreshToken;
    }
}