using Application.Users.Login;
using FluentValidation;
using Infrastructure._Common.Validations.ValidationErrorMessages;

namespace Infrastructure.Users.LogIn;

internal class LoginUserCommandValidator
    : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(model => model.Email)
            .NotEmpty()
                .WithMessage(GenericValidationErrorMessage.Required)
            .EmailAddress()
                .WithMessage(GenericValidationErrorMessage.InvalidFormat);

        RuleFor(model => model.Password)
            .NotEmpty()
                .WithMessage(GenericValidationErrorMessage.Required);
    }
}
