using Application._Common.Persistence.Databases;
using Application.Users.Register;
using FluentValidation;
using Infrastructure._Common.Validations;
using Infrastructure._Common.Validations.ValidationErrorMessages;
using Infrastructure._Persistence.Databases.ApplicationDbContext.Configurations;

namespace Infrastructure.Users.Register;

internal class RegisterUserCommandValidator
    : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator(IApplicationDbContext dbContext)
    {
        RuleFor(model => model.FullName)
            .NotEmpty()
                .WithMessage(GenericValidationErrorMessage.Required)
            .MaximumLength(UserConfiguration.FullNameLength)
                .WithMessage(GenericValidationErrorMessage.MaximumLength);

        RuleFor(model => model.Email)
            .NotEmpty()
                .WithMessage(GenericValidationErrorMessage.Required)
            .MaximumLength(UserConfiguration.EmailLength)
                .WithMessage(GenericValidationErrorMessage.MaximumLength)
            .EmailAddress()
                .WithMessage(GenericValidationErrorMessage.InvalidFormat)
            .NotExistAsync(dbContext.Users, entity => entity.Email)
                .WithMessage(GenericValidationErrorMessage.Conflict);
    }
}
