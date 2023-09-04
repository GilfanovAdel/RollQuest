using FluentValidation;

namespace Application.Services.AuthService.Validators;

public class RegistrationValidator : AbstractValidator<RegistrationRequest>
{
    public RegistrationValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Name).Length(2, 20);
    }
}