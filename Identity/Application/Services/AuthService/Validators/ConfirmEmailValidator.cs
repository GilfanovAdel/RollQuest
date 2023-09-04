using FluentValidation;

namespace Application.Services.AuthService.Validators;

public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailRequest>
{
    public ConfirmEmailValidator()
    {
        RuleFor(x => x.Code).NotNull().Length(6);
        RuleFor(x => x.Email).EmailAddress();
    }
}