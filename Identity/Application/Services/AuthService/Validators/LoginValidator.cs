using FluentValidation;

namespace Application.Services.AuthService.Validators;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
    }
}