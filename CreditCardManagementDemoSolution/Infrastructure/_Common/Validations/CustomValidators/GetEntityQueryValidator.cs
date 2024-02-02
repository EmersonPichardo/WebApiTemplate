using Application._Common.Queries;
using FluentValidation;

namespace Infrastructure._Common.Validations.CustomValidators;

internal abstract class GetEntityQueryValidator<TQuery>
    : AbstractValidator<TQuery>
    where TQuery : IGetEntityQuery
{
    protected GetEntityQueryValidator()
    {
        RuleFor(model => model.Id)
            .NotEmpty()
                .WithMessage(ValidationErrorMessages.Required);
    }
}
