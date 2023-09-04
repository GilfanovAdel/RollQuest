using Api.Filters;
using Application;
using Application.DTO;
using Application.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private IAuthService _authService;


    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [ValidationFilter<RegistrationRequest>]
    [HttpPost]
    [Route("registration")]
    public async Task Registration(RegistrationRequest request)
    {
         await _authService.Registration(request);
    }

    [ValidationFilter<ConfirmEmailRequest>]
    [HttpGet]
    [Route("confirmemail")]
    public async Task<object> ConfirmEmail([FromQuery] ConfirmEmailRequest request)
    {
        return await _authService.ConfirmEmail(request);
    }

    [ValidationFilter<ConfirmCodeRequest>]
    [HttpPost]
    [Route("confirmcode")]
    public async Task<object> ConfirmCode(ConfirmCodeRequest request)
    {
        return await _authService.ConfirmCode(request);
    }

    [ValidationFilter<LoginRequest>]
    [HttpPost]
    [Route("login")]
    public async Task Login(LoginRequest request)
    {
         await _authService.Login(request);
    }

    [HttpPost]
    [Route("refreshtoken")]
    public async Task<object> RefreshToken(string refreshToken)
    {
        return await _authService.RefreshToken(refreshToken);
    }
}