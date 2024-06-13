using Application._Common.Pagination;
using FluentValidation;

namespace Infrastructure._Common.Validations.CustomValidators;

internal abstract class GetEntitiesPaginatedQueryValidator<TQuery>
    : AbstractValidator<TQuery>
    where TQuery : IGetEntitiesPaginatedQuery
{
    protected GetEntitiesPaginatedQueryValidator()
    {
        RuleFor(model => model.CurrentPage)
            .GreaterThan(0)
                .WithMessage(ValidationErrorMessages.GreaterThan);

        RuleFor(model => model.PageSize)
            .GreaterThan(0)
                .WithMessage(ValidationErrorMessages.GreaterThan);
    }
}

