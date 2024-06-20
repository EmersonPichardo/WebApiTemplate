using Application.Users.Logout;
using FluentValidation;
using Infrastructure._Common.Validations.ValidationErrorMessages;

namespace Infrastructure.Users.Logout;

internal class LogoutUserCommandValidator
    : AbstractValidator<LogoutUserCommand>
{
    public LogoutUserCommandValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty()
                .WithMessage(GenericValidationErrorMessage.Required);
    }
}
