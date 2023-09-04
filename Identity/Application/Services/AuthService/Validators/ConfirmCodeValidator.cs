using FluentValidation;

namespace Application.Services.AuthService.Validators;

public class ConfirmCodeValidator : AbstractValidator<ConfirmCodeRequest>
{
    public ConfirmCodeValidator()
    {
        RuleFor(x => x.Code).NotNull().Length(6);
        RuleFor(x => x.Email).EmailAddress();
    }
}